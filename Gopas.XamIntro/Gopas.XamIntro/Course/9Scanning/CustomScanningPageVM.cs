using Xamarin.Forms;

namespace Gopas.XamIntro.Course._9Scanning
{
    class CustomScanningPageVM : ViewModelBase
    {
        #region Data binding
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
        #endregion
        INavigation Navigation { get; }

        public CustomScanningPageVM(INavigation navigation)
        {
            Navigation = navigation;
            FlashCommand = new Command(Flash);
            OnScannedCommand = new Command(OnScanned);

            isScanning = true;
        }

        /// <summary>
        /// Turn on or off flashligh
        /// </summary>
        void Flash()
        {
            IsTorchOn = !IsTorchOn;
        }
        /// <summary>
        /// Triggered when scanning is completed
        /// </summary>
        void OnScanned()
        {
            // pause scanning
            isAnalyzing = false;

            MessagingCenter.Send(Result, "CodeScanningCompleted");
            ClosePage();

            // only if you want to continue scanning
            //isAnalyzing = true;
        }

        /// <summary>
        /// Close this page after populating results
        /// </summary>
        void ClosePage()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
               await Navigation.PopAsync();
            });
        }
    }
}
