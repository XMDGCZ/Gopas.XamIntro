using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Gopas.XamIntro.Course._5DependencyService;
using Gopas.XamIntro.Droid;
using Plugin.CurrentActivity;
using Xamarin.Forms;

/// <summary>
/// Using official Google source for building notifications
/// https://developer.android.com/training/notify-user/build-notification
/// </summary>

[assembly: Dependency(typeof(NotificationProvider))]
namespace Gopas.XamIntro.Droid
{
    class NotificationProvider : INotificationProvider
    {
        internal static readonly string CHANNEL_ID = "my_notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;

        public void ShowNotification(string title, string text)
        {
            var context = CrossCurrentActivity.Current.Activity;
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                createNotificationChannel();
            }

            NotificationCompat.Builder mBuilder = new NotificationCompat.Builder(context, CHANNEL_ID )
                .SetContentTitle(title)
                .SetSmallIcon(Resource.Drawable.baseline_notification_important_white_18dp)
                .SetContentText(text)
                .SetPriority(NotificationCompat.PriorityDefault);

            NotificationManagerCompat notificationManager = NotificationManagerCompat.From(context);

            // notificationId is a unique int for each notification that you must define
            notificationManager.Notify(NOTIFICATION_ID, mBuilder.Build());
        }

        void createNotificationChannel()
        {
            var channel = new NotificationChannel(CHANNEL_ID, "Local Notifications", NotificationImportance.Default)
            {
                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.NotificationService);
            if (!notificationManager.NotificationChannels.Contains(channel))
            {
                notificationManager.CreateNotificationChannel(channel);
            }
        }
    }
}