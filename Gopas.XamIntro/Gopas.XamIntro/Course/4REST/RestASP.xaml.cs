using ServiceStack;
using SharedModel.Entity;
using SharedModel.ServiceInterface;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.Course._4REST
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestASP : ContentPage
    {
        const string apiUrl = "http://10.0.2.2:5080/api/ServiceStack?format=json";
        const string getAllItemsUrl = apiUrl + "GetItems/";
        const string singleItemUrl = apiUrl + "/";

        public RestASP()
        {
            InitializeComponent();
        }
               
        private async void getAllButtonClicked(object sender, EventArgs e)
        {
            waiting.IsRunning = true;
            if (isConnectedToInternet())
            {
                var client = new JsonServiceClient(apiUrl);
                List<SimpleDTO> response = await client.GetAsync(new GetSimpleDTO() );
                if(response != null)
                {
                    listView.ItemsSource = response;
                }
               
            }
            else
            {
                await DisplayAlert("Connection lost", "Not connected to Internet", "OK");
            }
            waiting.IsRunning = false;
        }

        bool isConnectedToInternet()
        {
            var networkAccess = Connectivity.NetworkAccess;
            return networkAccess == NetworkAccess.Internet;
        }
    }
}