using System;
using System.ComponentModel;
using System.IO;
using Plugin.FilePicker.Abstractions;
using SQLite;
using Xamarin.Forms;

namespace Mineral_Management.Models
{
    public class Product : JsonProduct
    {
        public ImageSource ListImg { get; set; }
    }
}