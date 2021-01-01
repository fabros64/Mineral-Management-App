using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Support.V4.Content;
using Java.IO;
using Mineral_Management.Droid.services;
using Mineral_Management.Services;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndroid))]
namespace Mineral_Management.Droid.services
{
    public class SaveAndroid: ISave
    {
        public async void Save(string fileName, String contentType, MemoryStream s)
        {        

            string root = null;
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
                root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Java.IO.File myDir = new Java.IO.File(root + "/Syncfusion");
            myDir.Mkdir();

            Java.IO.File file = new Java.IO.File(myDir, fileName);

            if (file.Exists()) file.Delete();

            try
            {
                FileOutputStream outs = new FileOutputStream(file);
                outs.Write(s.ToArray());

                outs.Flush();
                outs.Close();

            }
            catch (Exception e)
            {
            }
            if (file.Exists())
            {
                string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                Intent intent = new Intent(Intent.ActionView);
                intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
                Android.Net.Uri path = FileProvider.GetUriForFile(Forms.Context, Android.App.Application.Context.PackageName + ".provider", file);
                intent.SetDataAndType(path, mimeType);
                intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                Forms.Context.StartActivity(Intent.CreateChooser(intent, "Choose App"));


                //Android.Net.Uri path = Android.Net.Uri.FromFile(file);
                //string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                //string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                //Intent intent = new Intent(Intent.ActionView);
                //intent.SetDataAndType(path, mimeType);
                //Forms.Context.StartActivity(Intent.CreateChooser(intent, "Choose App"));
            }
        }      
       
        public static Activity activity { get; set; }

        public async System.Threading.Tasks.Task<byte[]> CaptureAsync()
        {
            var activity1 = Forms.Context as Activity;          

            var view = activity1.Window.DecorView;
            view.DrawingCacheEnabled = true;

            Bitmap bitmap = view.GetDrawingCache(true);

            byte[] bitmapData;

            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Jpeg, 0, stream);
                bitmapData = stream.ToArray();
            }

            return bitmapData;
        }
    }
}