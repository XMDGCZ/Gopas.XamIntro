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
            if (!AppCenter.Configured)
            {
                // Not called when app is in foreground on Android, use native workaround
                Push.PushNotificationReceived += (sender, e) =>
                {
                    // Add the notification message and title to the message
                    var summary = $"Push notification received:" +
                                        $"\n\tNotification title: {e.Title}" +
                                        $"\n\tMessage: {e.Message}";

                    // If there is custom data associated with the notification,
                    // print the entries
                    if (e.CustomData != null)
                    {
                        summary += "\n\tCustom data:\n";
                        foreach (var key in e.CustomData.Keys)
                        {
                            summary += $"\t\t{key} : {e.CustomData[key]}\n";
                        }
                    }

                    // Send the notification summary to debug output
                    System.Diagnostics.Debug.WriteLine(summary);
                };

                // Native workaround
                PushNotificationForegroundMessageReceiverRegistration();


                // Move all code from this page to App.cs
                // App center secrets
                AppCenter.Start("android=9af31a0c-2ff2-427a-83b2-cc50bccf6100;"
                    + "uwp={Your UWP App secret here};"
                    + "ios={Your iOS App secret here}",
                    typeof(Analytics), typeof(Crashes), typeof(Push));

            }
            Debug.WriteLine("Install ID:"+ await AppCenter.GetInstallIdAsync() );
        }

        /// <summary>
        /// Used for getting notification message body from native handler 
        /// Android.ForegroundFirebaseMessagingService.OnMessageReceived
        /// </summary>
        void PushNotificationForegroundMessageReceiverRegistration()
        {
            MessagingCenter.Subscribe<object, string>(this, "PushNotificationForegroundMessage", (sender, args) => 
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("PushNotificationForegroundMessage", args, "ok");
                });
            });
        }
    }
}