using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.Course._2Navigation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SimpleAlertPage : ContentPage
	{
		public SimpleAlertPage()
		{
			InitializeComponent ();
		}

        private async void ShowAlert(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Title", "Content text", "Yes", "No");
            if(response)
            {
              await DisplayAlert("Alert", "Answer is Yes","OK");
            }
            else await DisplayAlert("Alert", "Answer is No", "OK");
        }
    }
}