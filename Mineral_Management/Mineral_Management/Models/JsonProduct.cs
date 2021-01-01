using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace Mineral_Management.Models
{
    public class JsonProduct : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ProductId { get; set; }

        private string _name;
        [MaxLength(255)]
        public string Name { 
            get { return _name; } 
            set
            {
                if (_name == value)
                    return;
                _name = value;

                OnPropertyChanged();
            }
        }

        private string _description;
        [MaxLength(255)]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description == value)
                    return;
                _description = value;

                OnPropertyChanged();
            }
        }

        private string _imageSource = null;
        public string ImageSource {
            get
            {
                return _imageSource;
            }
            set
            {
                if (_imageSource == value)
                    return;

                _imageSource = value;

            }
        }

        private string _imageName = null;
        public string ImageName
        {
            get { return _imageName; }
            set
            {
                if (_imageName == value)
                    return;
                _imageName = value;

                OnPropertyChanged();
            }
        }
        public Minerals Minerals { get; set; } = new Minerals();

        public string UserId { get; set; }
    }
}
