using Gopas.XamIntro.Course._2Navigation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.Course._2Navigation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SimpleNavigationPage : ContentPage
	{
		public SimpleNavigationPage ()
		{
			InitializeComponent ();
		}

        private async void Navigate(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SimpleContentPage());

        }
        private async void NavigateModal(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SimpleContentPage());

        }
    }
}