using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Mineral_Management.Models;
using Mineral_Management.Services;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Prism.Commands;
using Prism.Navigation.Xaml;
using Xamarin.Forms;

namespace Mineral_Management.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private FileData fd = null;
        private DelegateCommand _filePickCommand;
        private DelegateCommand _saveCommand;
        private DelegateCommand _cancelCommand;

        public Product Item { get; set; }

        public DelegateCommand FilePickCommand =>
            _filePickCommand ?? (_filePickCommand = new DelegateCommand(async () => await ExecuteFilePickCommand()));
        public DelegateCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand(async () => await ExecuteSaveCommand()));
        public DelegateCommand CancelCommand =>
            _cancelCommand ?? (_cancelCommand = new DelegateCommand(async () => await ExecuteCancelCommand()));


        public NewItemViewModel()
        {
            Item = new Product
            {
                Name = "Item name",
                Description = "This is an item description.",
            };

            Title = "Add new product";
            _pageService = new PageService();
        }

        private async Task ExecuteFilePickCommand()
        {
            try
            {
                fd = await CrossFilePicker.Current.PickFile(new string[] { ".jpg", ".png" });
                if (fd != null)
                {
                    Item.ImageName = await Task.FromResult(fd.FileName);
                    Stream stream = await Task.FromResult(fd.GetStream());
                    Item.ListImg = await Task.FromResult(ImageSource.FromStream(() => stream));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task ExecuteSaveCommand()
        {
            byte[] dataBytes = null;

            if (fd != null)
                dataBytes = fd.DataArray;

            if (dataBytes != null)
                Item.ImageSource = Convert.ToBase64String(dataBytes);
            else
                Item.ImageSource = null;

            if (Item.Name == "" || Item.Description == "")
                await _pageService.DisplayAlert("Adding new product", "please complete all fields", "OK");
            else
            {
                MessagingCenter.Send(this, "AddItem", Item);
                await _pageService.PopModalAsync();
            }
        }

        private async Task ExecuteCancelCommand()
        {
            await _pageService.PopModalAsync();
        }
    }
}
