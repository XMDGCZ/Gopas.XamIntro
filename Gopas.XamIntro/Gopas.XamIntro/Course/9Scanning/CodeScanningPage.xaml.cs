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
    public partial class CodeScanningPage : ContentPage
    {
        public Command NavigateToScanPageCommand { get; set; }
        public CodeScanningPage()
        {
            NavigateToScanPageCommand = new Command(async () => await NavgiateToScanPage());
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
    }
}