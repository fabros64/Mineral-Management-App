using System;
using System.IO;
using Mineral_Management.Models;
using Mineral_Management.Services;
using Mineral_Management.Views;
using Plugin.FilePicker.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using Prism.Navigation.Xaml;
using Xamarin.Forms;

namespace Mineral_Management.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _navigateCommand;
        private DelegateCommand _AddCommand;
        private DelegateCommand _DeleteCommand;

        public INavigation Navigation { get; set; }
        public ImageSource imageSource { get; set; }
        public string AmountEntry { get; set; } = "";
        

        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));
        public DelegateCommand AddCommand =>
            _AddCommand ?? (_AddCommand = new DelegateCommand(ExecuteAddCommand));
        public DelegateCommand DeleteCommand =>
            _DeleteCommand ?? (_DeleteCommand = new DelegateCommand(ExecuteDeleteCommand));

        private async void ExecuteDeleteCommand()
        {
            if (Item.UserId != App.User)
                await _pageService.DisplayAlert("Delete product", "You don't have permission to do it", "OK");
            else
            {
                var response = await _pageService.DisplayAlert("Delete Product", "Are you sure?", "Yes", "No");
                if (response)
                {
                    MessagingCenter.Send(this, "DeleteItem", Item.ProductId);
                    await Navigation.PopToRootAsync();
                }
            }
        }

        async void ExecuteNavigateCommand()
        {
            await _navigationService.SelectTabAsync("selectedTab=CalculationPage");
            //await _navigationService.SelectTabAsync("CalculationPage");
        }

        private async void ExecuteAddCommand()
        {
            if (AmountEntry == "")
            {
                await _pageService.DisplayAlert("Error", "Please enter the product amount", "OK");
            }
            else if (int.TryParse(AmountEntry.ToString(), out var entry))
            {
                DailyDietProduct ddProduct = new DailyDietProduct
                {
                    ProductId = Item.ProductId,
                    Amount = entry
                };
                MessagingCenter.Send(this, "AddItem", ddProduct);

                await _pageService.DisplayAlert("Add to calculation",
                    "the product has been successfully added to the calculation page", "OK");

                var main = Application.Current.MainPage as MainPage;
                main?.SwitchToCalculation();
                await Navigation.PopToRootAsync();
            }
            else
                await _pageService.DisplayAlert("Error", "Please enter correct format of product amount", "OK");
        }

        public Product Item { get; set; }
        public ItemDetailViewModel(Product item, INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = item?.Name;
            Item = item;

            if (Item.ImageSource != null)
                imageSource = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(Item.ImageSource)));

            _pageService = new PageService();
        }
    }
}
