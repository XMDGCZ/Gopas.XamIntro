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
        public Task PageClosedTask { get { return tcs.Task; } }




        public CustomScanningPage()
        {
            InitializeComponent();
            tcs = new TaskCompletionSource<ZXing.Result>();
            viewModel = new CustomScanningPageVM(tcs, Navigation);

            this.BindingContext = viewModel;
  

            scanView.Options.DelayBetweenAnalyzingFrames = 5;
            scanView.Options.DelayBetweenContinuousScans = 5;
        }

        private TaskCompletionSource<ZXing.Result> tcs { get; set; }
    }
}