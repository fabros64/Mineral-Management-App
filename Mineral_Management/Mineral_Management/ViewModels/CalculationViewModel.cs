using Mineral_Management.Models;
using Mineral_Management.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Xamarin.Forms;

namespace Mineral_Management.ViewModels
{
    public class CalculationViewModel : BaseViewModel
    {
        public ObservableCollection<DailyDietProduct> DailyDietProductsList { get; set; }
        public Command LoadItemsCommand { get; set; }

        public async Task<FinalReportOfDailyMineralsIntake> CreateReport(Person person)
        {
            PersonNutrientsDailyIntake personNDI = new PersonNutrientsDailyIntake(person);
            var products = await DataStore.GetItemsAsync();

            DailyDietSumOfMinerals sumMinerals =
                new DailyDietSumOfMinerals(DailyDietProductsList.ToList(), products.ToList());
            return new FinalReportOfDailyMineralsIntake(personNDI, sumMinerals);
        }

        public CalculationViewModel()
        {
            Title = "Mineral Calculation";

            DailyDietProductsList = new ObservableCollection<DailyDietProduct>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<ItemDetailViewModel, DailyDietProduct>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as DailyDietProduct;

                Product product = await DataStore.GetItemAsync(newItem.ProductId);
                newItem.Name = product.Name.ToString();
                DailyDietProductsList.Add(newItem);
                await SQLiteDataStore.AddItemAsync(newItem);
            });
            MessagingCenter.Subscribe<CalculationPage, DailyDietProduct>(this, "DeleteProduct", async (obj, item) =>
            {
                var productToDelete = item as DailyDietProduct;

                DailyDietProductsList.Remove(productToDelete);
                await SQLiteDataStore.DeleteItemAsync(productToDelete.Id.ToString());
            });

            MessagingCenter.Subscribe<ItemDetailViewModel, string>(this, "DeleteItem", async (page, s) =>
            {
                await ExecuteLoadItemsCommand();
            });
        }

        public async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                bool forceRefresh = DailyDietProductsList.Count == 0;
                DailyDietProductsList.Clear();
                var items = await SQLiteDataStore.GetItemsAsync(forceRefresh);
                var dataItems = await DataStore.GetItemsAsync(forceRefresh);
                var jsonProducts = dataItems.ToList();
                var mongoItems = !jsonProducts.Any() ? await MongoDataStore.GetItemsAsync(forceRefresh) : jsonProducts;
                var products = mongoItems.ToList();
                var dailyDietProducts = items.ToList();

                if (products.Any())
                {
                    foreach (var item in dailyDietProducts)
                    {
                        var product = products.FirstOrDefault(mi => mi.ProductId == item.ProductId);
                        if (product != null)
                            DailyDietProductsList.Add(item);
                        else
                            await SQLiteDataStore.DeleteItemAsync(item.Id.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand OpenWebCommand { get; }
    }
}