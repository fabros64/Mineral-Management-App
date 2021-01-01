#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;
using Mineral_Management.Services;
using Mineral_Management.UWP.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveWindows))]
namespace Mineral_Management.UWP.Services
{
    class SaveWindows: ISaveWindowsPhone
    {
        public async Task<byte[]> CaptureAsync()
        {
            var logicalDpi = DisplayInformation.GetForCurrentView().LogicalDpi;
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap();            
            await renderTargetBitmap.RenderAsync(Window.Current.Content);
            var pixelBuffer = await renderTargetBitmap.GetPixelsAsync();
            var pixels = pixelBuffer.ToArray();           
            var displayInformation = DisplayInformation.GetForCurrentView();
            var stream = new InMemoryRandomAccessStream();
            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
            encoder.SetPixelData(BitmapPixelFormat.Bgra8,
            BitmapAlphaMode.Premultiplied,
            (uint)renderTargetBitmap.PixelWidth,
            (uint)renderTargetBitmap.PixelHeight,
            displayInformation.RawDpiX,
            displayInformation.RawDpiY,
            pixels);
            await encoder.FlushAsync();
            stream.Seek(0);
            var readStram = stream.AsStreamForRead();
            var bytes = new byte[readStram.Length];
            readStram.Read(bytes, 0, bytes.Length);
            return bytes;
        }

        public async Task Save(string filename, string contentType, MemoryStream stream)
        {
            if (Device.Idiom != TargetIdiom.Desktop)
            {
                StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFile outFile = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                using (Stream outStream = await outFile.OpenStreamForWriteAsync())
                {
                    outStream.Write(stream.ToArray(), 0, (int)stream.Length);
                }
                if (contentType != "application/html")
                    await Windows.System.Launcher.LaunchFileAsync(outFile);
            }
            else
            {
                StorageFile storageFile = null;
                FileSavePicker savePicker = new FileSavePicker();
                savePicker.SuggestedStartLocation = PickerLocationId.Desktop;
                savePicker.SuggestedFileName = filename;
                switch (contentType)
                {
                    case "application/vnd.openxmlformats-officedocument.presentationml.presentation":
                        savePicker.FileTypeChoices.Add("PowerPoint Presentation", new List<string>() { ".pptx", });
                        break;

                    case "application/msexcel":
                        savePicker.FileTypeChoices.Add("Excel Files", new List<string>() { ".xlsx", });
                        break;

                    case "application/msword":
                        savePicker.FileTypeChoices.Add("Word Document", new List<string>() { ".docx" });
                        break;

                    case "application/pdf":
                        savePicker.FileTypeChoices.Add("Adobe PDF Document", new List<string>() { ".pdf" });
                        break;
                    case "application/html":
                        savePicker.FileTypeChoices.Add("HTML Files", new List<string>() { ".html" });
                        break;
                }
                storageFile = await savePicker.PickSaveFileAsync();

                using (Stream outStream = await storageFile.OpenStreamForWriteAsync())
                {
                    outStream.Write(stream.ToArray(), 0, (int)stream.Length);
                    outStream.Flush();
                    outStream.Dispose();
                }
                stream.Flush();
                stream.Dispose();
                await Windows.System.Launcher.LaunchFileAsync(storageFile);
            }
        }
    }
}
