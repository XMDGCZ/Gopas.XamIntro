using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private string scanningResutlText = "Scan your code";

        public string ScanningResutlText
        {
            get { return scanningResutlText; }
            set { scanningResutlText = value;
                OnPropertyChanged("ScanningResutlText");
            }
        }

        public ScanningPage()
        {
            NavigateToScanPageCommand = new Command(async () => await NavigateToScanPage());
            NavigateToCustomScanPageCommand = new Command(async () => await GetCodeFromCustomScanningPage());
            InitializeComponent();
        }

        /// <summary>
        /// Use standard scanning page
        /// </summary>
        /// <returns></returns>
        async Task NavigateToScanPage()
        {
            ZXingScannerPage scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopAsync();
                    DisplayAlert("Scanned Barcode", result.Text, "OK");
                    ScanningResutlText = result.Text;
                });
            };
            await Navigation.PushAsync(scanPage);
        }

        /// <summary>
        /// Use Custom scanning page
        /// </summary>
        /// <returns></returns>
        async Task GetCodeFromCustomScanningPage()
        {
            var page = new CustomScanningPage();
            await Navigation.PushAsync(page);
            MessagingCenter.Subscribe<ZXing.Result>(this, "CodeScanningCompleted", (code) =>
            {
                Debug.WriteLine($"Text from Scanning Page: {code.Text}");
                ScanningResutlText = code.Text;
            });
        }
    }
}