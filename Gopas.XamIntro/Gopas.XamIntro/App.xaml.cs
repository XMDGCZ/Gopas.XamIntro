using Gopas.XamIntro.BaseMasterDetailPage;
using Gopas.XamIntro.BaseMasterDetailPage.Pages;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Gopas.XamIntro
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Master();

            if (!AppCenter.Configured)
            {
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



                // Move all code from this page to App.cs
                // App center secrets
                AppCenter.Start("9af31a0c-2ff2-427a-83b2-cc50bccf6100;"
                    + "uwp={Your UWP App secret here};"
                    + "ios={Your iOS App secret here}",
                    typeof(Analytics), typeof(Crashes), typeof(Push));

            }
            }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
