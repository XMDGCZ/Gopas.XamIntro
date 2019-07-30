using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Gopas.XamIntro.Course._9Scanning
{
    class CustomScanningPageVM : ViewModelBase
    {
        public Command FlashCommand { get; set; }
        public Command OnScannedCommand { get; set; }
        bool isTorchOn = false;
        public bool IsTorchOn
        {
            get
            {
                return isTorchOn;
            }
            set
            {
                isTorchOn = value;
                OnPropertyChanged();
            }
        }
        private bool isScanning;

        public bool IsScanning
        {
            get
            {
                return isScanning;
            }
            set
            {
                isScanning = value;
                OnPropertyChanged();
            }
        }

        private bool isAnalyzing;

        public bool IsAnalyzing
        {
            get { return isAnalyzing; }
            set
            {
                isAnalyzing = value;
                OnPropertyChanged();
            }
        }

        private ZXing.Result result;

        public ZXing.Result Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged();
            }
        }

        TaskCompletionSource<ZXing.Result> tcs { get; }
        INavigation Navigation { get; }

        public CustomScanningPageVM(TaskCompletionSource<ZXing.Result> tcs, INavigation navigation)
        {
            FlashCommand = new Command(Flash);
            OnScannedCommand = new Command(OnScanned);

            isScanning = true;
            this.tcs = tcs;
            Navigation = navigation;
        }

        void Flash()
        {
            IsTorchOn = !IsTorchOn;
        }

        void OnScanned()
        {
            isAnalyzing = false;
            string message = String.Format("I read a barcode and found the value: {0}", Result.Text);
            Debug.WriteLine(message);

            tcs.SetResult(result);
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Navigation.PopAsync();
            });

            isAnalyzing = true;
        }
    }
}
