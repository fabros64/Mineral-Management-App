using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mineral_Management.Services
{
    public class PageService : IPageService
    {
        public async Task PushAsync(Page page)
        {
           await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task PopModalAsync()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
           return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }
        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }
    }
}
