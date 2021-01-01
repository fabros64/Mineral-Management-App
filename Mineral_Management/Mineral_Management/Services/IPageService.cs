using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mineral_Management.Services
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task PopModalAsync();
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task DisplayAlert(string title, string message, string cancel);
    }
}
