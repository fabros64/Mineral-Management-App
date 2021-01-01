using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Mineral_Management.Models;
using Mineral_Management.ViewModels;
using Plugin.FilePicker;
using System.IO;
using System.Linq;
using System.Text;
using Prism;
using Prism.Ioc;
using Prism.Navigation;

namespace Mineral_Management.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            viewModel.Navigation = this.Navigation;
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            if (!double.TryParse(Calcium.Text, out double ca) || !double.TryParse(Copper.Text, out double co) || !double.TryParse(Iron.Text, out double i) ||
                !double.TryParse(Magnesium.Text, out double mg) || !double.TryParse(Phosphorus.Text, out double p) || !double.TryParse(Potassium.Text, out double po) ||
                !double.TryParse(Selenium.Text, out double se) || !double.TryParse(Sodium.Text, out double so) || !double.TryParse(Zinc.Text, out double zn))
                await DisplayAlert("Edit Product", "please complete correctly all fields", "OK");
            else if (viewModel.Item.UserId != App.User)
                await DisplayAlert("Edit product", "You don't have permission to do it", "OK");
            else
            {
                MessagingCenter.Send(this, "EditProduct", viewModel.Item);
                await Navigation.PopToRootAsync();
            }

        }

    }
}