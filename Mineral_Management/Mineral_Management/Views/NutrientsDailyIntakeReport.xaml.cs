using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mineral_Management.Services;
using Mineral_Management.ViewModels;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;

namespace Mineral_Management.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NutrientsDailyIntakeReport : ContentPage
    {
        ReportViewModel viewModel;
        public NutrientsDailyIntakeReport(ReportViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }


        #region XAMLtoPDF - attempt

        /* private async void SaveReport_Clicked(object sender, EventArgs e)
         {
             //Create a new PDF document
             PdfDocument document = new PdfDocument();
             //Add page to the PDF document
             PdfPage page = document.Pages.Add();
             //Create graphics instance
             PdfGraphics graphics = page.Graphics;
             Stream imageStream = null;


             //Captures the XAML page as image and returns the image in memory stream
             if (Device.RuntimePlatform == Device.UWP)
                 imageStream = new MemoryStream(DependencyService.Get<ISaveWindowsPhone>().CaptureAsync().Result);
             else imageStream = new MemoryStream(DependencyService.Get<ISave>().CaptureAsync().Result);

             //Load the image in PdfBitmap
             PdfBitmap image = new PdfBitmap(imageStream);

             //Draw the image to the page
             graphics.DrawImage(image, 0, 0, page.GetClientSize().Width, page.GetClientSize().Height);


             //Save the document into memory stream
             MemoryStream stream = new MemoryStream();
             document.Save(stream);

             stream.Position = 0;
             //Save the stream as a file in the device and invoke it for viewing
             PermissionStatus status = await CrossPermissions.Current.RequestPermissionAsync<StoragePermission>();
             if (Device.RuntimePlatform == Device.UWP)
             {
                await Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("Report.pdf", "application/pdf", stream);
             }
             else
             {
                  Xamarin.Forms.DependencyService.Get<ISave>().Save("Report.pdf", "application/pdf", stream);
             }
         }*/
        #endregion
    }
}