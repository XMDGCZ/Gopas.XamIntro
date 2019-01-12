using Gopas.XamIntro.BaseMasterDetailPage;
using Gopas.XamIntro.BaseMasterDetailPage.Pages;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using Newtonsoft.Json;
using SharedModel;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Gopas.XamIntro
{
    public partial class App : Application
    {
        public App()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Objects,
                Converters = new List<JsonConverter>
                {
                    new DefaultJsonConverter()
                }
            };

            InitializeComponent();

            MainPage = new Master();

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
