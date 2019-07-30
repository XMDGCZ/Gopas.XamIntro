using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.Course._9Scanning
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomScanningPage : ContentPage
    {
        CustomScanningPageVM viewModel;
       public CustomScanningPage()
        {
            InitializeComponent();
            SetUpScanner();

            // set up ViewModel
            viewModel = new CustomScanningPageVM(Navigation);
            this.BindingContext = viewModel;
        }

        void SetUpScanner()
        {
            scanView.Options.DelayBetweenAnalyzingFrames = 5;
            scanView.Options.DelayBetweenContinuousScans = 5;
        }
    }
}