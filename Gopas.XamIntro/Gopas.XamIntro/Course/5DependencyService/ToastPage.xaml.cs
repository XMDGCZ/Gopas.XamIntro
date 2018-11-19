using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.Course._5DependencyService
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToastPage : ContentPage
	{
		public ToastPage()
		{
			InitializeComponent ();
		}

        private void ToastButton_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IToastProvider>().ShowToastMessge(ToastMessageEntry.Text);
        }
    }
}