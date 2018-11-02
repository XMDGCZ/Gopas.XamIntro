using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Gms.Common;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Gopas.XamIntro.Course._5Firebase;
using Xamarin.Forms;
using Gopas.XamIntro.Droid;
using Firebase.Iid;
// https://docs.microsoft.com/cs-cz/xamarin/android/data-cloud/google-messaging/remote-notifications-with-fcm?tabs=vswin
[assembly: Dependency(typeof(FCMService))]
namespace Gopas.XamIntro.Droid
{
    class FCMService : IFCMService
    {
        static readonly string TAG = "MainActivity";

        internal static readonly string CHANNEL_ID = "my_notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;

        public bool CheckGooglePlayServicesAvailibility()
        {
            return IsPlayServicesAvailable();
        }

        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(Android.App.Application.Context);
            if (resultCode != ConnectionResult.Success)
            {
                if(Build.VERSION.SdkInt >= BuildVersionCodes.O)
                {
                    CreateNotificationChannel();
                }
                return GoogleApiAvailability.Instance.IsUserResolvableError(resultCode);
            }
            else
            {
                return true;
            }
        }

        void CreateNotificationChannel()
        {
            var channel = new NotificationChannel(CHANNEL_ID, "FCM Notifications", NotificationImportance.Default)
            {
                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.NotificationService);
            if (!notificationManager.NotificationChannels.Contains(channel))
            {
                notificationManager.CreateNotificationChannel(channel);
            }
        }

        public string GetToken()
        {
            return FirebaseInstanceId.Instance.Token;
        }

        public string GetGoogleAppID()
        {
             return ((MainActivity)Forms.Context).GetString(Resource.String.google_app_id);
        }
    }
}