using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Mineral_Management.Models;
using Mineral_Management.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mineral_Management.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculationPage : ContentPage
    {
        private CalculationViewModel viewModel;
        private bool isTextChanged = false;
        public CalculationPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CalculationViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadItemsCommand.Execute(null);
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ItemsListView.SelectedItem = null;
        }

        private async void DeleteDailyProduct_Clicked(object sender, EventArgs e)
        {
            var entry = sender as ImageButton;
            DailyDietProduct ddP = entry.BindingContext as DailyDietProduct;
            var response = await DisplayAlert("Delete " + ddP.Name, "Are you sure?", "Yes", "No");
            if (response)
            {
                MessagingCenter.Send(this, "DeleteProduct", ddP);
            }
        }

        private void EditDailyProduct_Clicked(object sender, EventArgs e)
        {
            var entry = sender as ImageButton;
            DailyDietProduct ddP = entry.BindingContext as DailyDietProduct;
            EditAmount(ddP);
        }

        private void Entry_OnCompleted(object sender, EventArgs e)
        {
            var entry = sender as Entry;
            DailyDietProduct ddP = entry.BindingContext as DailyDietProduct;
            EditAmount(ddP);
        }

        private void Amount_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            isTextChanged = true;
        }

        private void Amount_Unfocused(object sender, FocusEventArgs e)
        {
            DailyDietProduct ddP = e.VisualElement.BindingContext as DailyDietProduct;
            EditAmount(ddP);
        }

        private void Amount_Focused(object sender, FocusEventArgs e)
        {
            isTextChanged = false;
        }

        private async void EditAmount(DailyDietProduct ddP)
        {
            if (isTextChanged)
            {
                await viewModel.SQLiteDataStore.UpdateItemAsync(ddP);
            }
        }

        private async void GenerateButton_Clicked(object sender, EventArgs e)
        {
            if(viewModel.DailyDietProductsList.Count == 0)
                await DisplayAlert("Generate Report", "There is no product to generate the report", "OK");
            else
            {
                Gender gender = (bool) ManRb.IsChecked ? Gender.Man : Gender.Woman;
                int age = (int) Math.Round(AgeSlider.Value);

                var report = await viewModel.CreateReport(new Person(gender, age));
                await Navigation.PushAsync(new NutrientsDailyIntakeReport(new ReportViewModel(report)));
            }
        }
    }
}