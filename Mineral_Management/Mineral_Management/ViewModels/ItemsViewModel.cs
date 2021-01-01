using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Mineral_Management.Models;
using Mineral_Management.Views;
using Mineral_Management.Services;
using Newtonsoft.Json;

namespace Mineral_Management.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Product>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemViewModel, Product>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Product;
                if(newItem.ImageSource != null)
                    newItem.ListImg = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(newItem.ImageSource)));

                newItem.ProductId = Guid.NewGuid().ToString();
                newItem.UserId = App.User;
                Items.Add(newItem);

                JsonProduct jp = new JsonProduct
                {
                    ProductId = newItem.ProductId,
                    Description = newItem.Description,
                    Name = newItem.Name,
                    Minerals = newItem.Minerals,
                    ImageName = newItem.ImageName,
                    ImageSource = newItem.ImageSource,
                    UserId = newItem.UserId
                };

                await DataStore.AddItemAsync(newItem);
                await MongoDataStore.AddItemAsync(jp);
                //await ExecuteLoadItemsCommand();
            });

            MessagingCenter.Subscribe<ItemDetailViewModel, string>(this, "DeleteItem", async (page, s) =>
            {
                var productId = s as string;
                Items.Remove(Items.FirstOrDefault(i => i.ProductId == productId));
                await DataStore.DeleteItemAsync(productId);
                await MongoDataStore.DeleteItemAsync(productId);
                var sqliteItems = await SQLiteDataStore.GetItemsAsync();
                foreach (var sqliteItem in sqliteItems.ToList())
                {
                    if (sqliteItem.ProductId == productId)
                        await SQLiteDataStore.DeleteItemAsync(sqliteItem.Id.ToString());
                }
                //await ExecuteLoadItemsCommand();
            });

            MessagingCenter.Subscribe<ItemDetailPage, Product>(this, "EditProduct", async (page, s) =>
            {
                var product = s as Product;
                JsonProduct jp = new JsonProduct
                {
                    ProductId = product.ProductId,
                    Description = product.Description,
                    Name = product.Name,
                    Minerals = product.Minerals,
                    ImageName = product.ImageName,
                    ImageSource = product.ImageSource,
                    UserId = product.UserId
                };
                var oldItem = Items.Where((Product arg) => arg.ProductId == product.ProductId).FirstOrDefault();
                Items.Remove(oldItem);
                Items.Add(product);
                await DataStore.UpdateItemAsync(product);
                await MongoDataStore.UpdateItemAsync(jp);
                var sqliteItems = await SQLiteDataStore.GetItemsAsync();
                
                foreach (var sqliteItem in sqliteItems.ToList())
                {
                    if (sqliteItem.ProductId == product.ProductId)
                    {
                        sqliteItem.Name = product.Name;
                        await SQLiteDataStore.UpdateItemAsync(sqliteItem);
                    }
                }
            });
        }

        public async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await MongoDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Product product = new Product
                    {
                        ProductId = item.ProductId,
                        Name = item.Name,
                        Description = item.Description,
                        Minerals = item.Minerals,
                        ImageName = item.ImageName,
                        ImageSource = item.ImageSource,
                        UserId = item.UserId
                    };
                    if (item.ImageSource != null)
                        product.ListImg = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(item.ImageSource)));
                    Items.Add(product);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                foreach (var item in Items)
                {
                    await DataStore.AddItemAsync(item);
                }
                IsBusy = false;
            }
        }
    }
}