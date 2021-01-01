using SQLite;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mineral_Management.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void SwitchToItems()
        {
            CurrentPage = Items;
        }

        public void SwitchToCalculation()
        {
            CurrentPage = Calculation;
        }
    }
}