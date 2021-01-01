using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Mineral_Management.Models;
using Mineral_Management.Views;
using Mineral_Management.ViewModels;
using Prism.Navigation;
using SQLite;
using Xamarin.Essentials;

namespace Mineral_Management.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Product;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item,App.navigationService)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                await DisplayAlert("Internet access alert",
                    "You don't have internet access, the application will not work properly. " +
                    "Please connect to the internet first",
                    "OK");

            else if (viewModel.Items.Count == 0)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ItemsListView.ItemsSource = viewModel.Items.Where(p => p.Name.ToUpper().Contains(e.NewTextValue.ToUpper()));
        }
    }
}