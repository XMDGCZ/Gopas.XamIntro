using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.Course.GUIComponents._2Navigation
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
    }
}