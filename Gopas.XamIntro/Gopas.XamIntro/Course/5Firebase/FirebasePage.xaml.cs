
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.Course._5Firebase
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirebasePage : ContentPage
    {
        public FirebasePage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<object, string>(this, "Hi", (sender, args) => {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert("Notification body", args, "ok");
                });
            });
        }

        private void CheckAvailabilityClick(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                IFCMService fCMService = DependencyService.Get<IFCMService>();
                if (fCMService.CheckGooglePlayServicesAvailibility())
                {
                    PlayServicesStatusLabel.Text = "Available";
                    PlayServicesStatusLabel.TextColor = Color.Green;
                    Debug.WriteLine("registration token: " + fCMService.GetToken());
                    Debug.WriteLine("Google App ID: " + fCMService.GetGoogleAppID());

                }
                else
                {
                    PlayServicesStatusLabel.Text = "Not available";
                    PlayServicesStatusLabel.TextColor = Color.Red;

                }
            }
        }
    }
}