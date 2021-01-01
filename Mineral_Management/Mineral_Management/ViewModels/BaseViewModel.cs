using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using Mineral_Management.Models;
using Mineral_Management.Services;
using Prism.Mvvm;

namespace Mineral_Management.ViewModels
{
    public class BaseViewModel : BindableBase, INotifyPropertyChanged
    {
        protected IPageService _pageService;
        public IDataStore<Product> DataStore => DependencyService.Get<IDataStore<Product>>();
        public IDataStore<JsonProduct> MongoDataStore => DependencyService.Get<IDataStore<JsonProduct>>();
        public IDataStore<DailyDietProduct> SQLiteDataStore => DependencyService.Get<IDataStore<DailyDietProduct>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string textForLabel;

        public string TextForLabel
        {
            get => this.textForLabel;
            set => SetProperty(ref this.textForLabel, value);
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
