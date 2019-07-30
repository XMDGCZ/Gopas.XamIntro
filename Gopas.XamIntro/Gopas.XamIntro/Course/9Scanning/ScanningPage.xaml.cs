using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Gopas.XamIntro.Course._9Scanning
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanningPage : ContentPage
    {
        public Command NavigateToScanPageCommand { get; set; }
        public Command NavigateToCustomScanPageCommand { get; set; }
        public ScanningPage()
        {
            NavigateToScanPageCommand = new Command(async () => await NavgiateToScanPage());
            NavigateToCustomScanPageCommand = new Command(async () => await NavigateToCustomScanningPage());
            InitializeComponent();

        }

        async Task NavgiateToScanPage()
        {
            ZXingScannerPage scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) => {
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();
                    DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };

            await Navigation.PushAsync(scanPage);
        }

        async Task NavigateToCustomScanningPage()
        {
            var page = new CustomScanningPage();
            await Navigation.PushAsync(page);
            await page.PageClosedTask;
        }
    }
}