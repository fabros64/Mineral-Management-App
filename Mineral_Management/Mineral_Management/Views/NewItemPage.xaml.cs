using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Mineral_Management.Models;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Mineral_Management.ViewModels;

namespace Mineral_Management.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}