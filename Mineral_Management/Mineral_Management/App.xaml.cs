using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mineral_Management.Views;
using Mineral_Management.Services;
using Mineral_Management.ViewModels;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Unity;
using Xamarin.Essentials;


namespace Mineral_Management
{
    public partial class App : PrismApplication
    {
        public static string AzureBackendUrl = "https://mineralmanagement.azurewebsites.net/";
        //DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5002" : "http://localhost:5002";
        public static bool UseMockDataStore = true;
        public static INavigationService navigationService;

        public static string User;
        public App(IPlatformInitializer platformInitializer = null):base(platformInitializer)
        {
            // MainPage = new MainPage();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ItemsPage>();
            containerRegistry.RegisterForNavigation<CalculationPage>();
        }

        protected override async void OnInitialized()
        {
            if (!Application.Current.Properties.ContainsKey("User"))
            {
                Application.Current.Properties["User"] = Guid.NewGuid();
                await Application.Current.SavePropertiesAsync();
            }

            User = Application.Current.Properties["User"].ToString();
            

            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjY0Mjg2QDMxMzgyZTMxMmUzMEhWOXZEMTBncmFDWUsvWUZsTlBiNWNQeFhObGNiTjVYZlV3aDUxdTNxU2c9");
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<SQLiteDataStore>();
            DependencyService.Register<MongoDataStore>();

            App.navigationService = NavigationService;
            await this.NavigationService.NavigateAsync("MainPage");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            DependencyService.Get<ISQLiteDb>().GetConnection().CloseAsync();
        }

        protected override void OnResume()
        {
        }
    }
}
