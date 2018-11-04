using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.Course._5Push
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppCenterPage : ContentPage
    {
        public AppCenterPage()
        {
            InitializeComponent();

            AppCenterInit();
        }


        async void AppCenterInit()
        {
  

               Debug.WriteLine("Install ID:"+ await AppCenter.GetInstallIdAsync() );
            
        }
    }
}