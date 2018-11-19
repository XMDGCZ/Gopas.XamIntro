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
	public partial class LocalNotificationPage : ContentPage
	{
		public LocalNotificationPage ()
		{
			InitializeComponent ();
		}

        private void NotificationButton_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<INotificationProvider>().ShowNotification(NotifictionTitleEntry.Text, NotifictionEntryText.Text);
        }
    }
}