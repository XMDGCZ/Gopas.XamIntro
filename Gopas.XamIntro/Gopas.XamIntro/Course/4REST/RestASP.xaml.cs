using ServiceStack;
using SharedModel.Entity;
using SharedModel.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.Course._4REST
{
    enum Formats { json, csv, xml }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestASP : ContentPage
    {
        const string URL = baseURL + URLItem + defaultFormat;
        const string baseURL = "http://10.0.2.2:5080/api/";
        const string URLItem = "ServiceStack/";
        const string format = "";
        const string defaultFormat = format + nameof(Formats.json);

        public RestASP()
        {
            InitializeComponent();
        }
               
        private async void getAllButtonClicked(object sender, EventArgs e)
        {
            waiting.IsRunning = true;
            var items = await Task.Run<List<SimpleDTO>>( async () =>
            {
                if (isConnectedToInternet())
                {
                    var client = new JsonServiceClient(URL);
                    List<SimpleDTO> response = await client.GetAsync(new GetSimpleDTO());
                    return response;
                }
                else
                {
                    await DisplayAlert("Connection lost", "Not connected to Internet", "OK");
                    return null;
                }
            });
            if (!items.IsErrorResponse() && !items.IsNullOrEmpty())
            {
                listView.ItemsSource = items;
            }
            waiting.IsRunning = false;
        }

        bool isConnectedToInternet()
        {
            var networkAccess = Connectivity.NetworkAccess;
            return networkAccess == NetworkAccess.Internet;
        }

        private async void postButtonClicked(object sender, EventArgs e)
        {
            waiting.IsRunning = true;
            var items = await Task.Run<SimpleDTO>(async () =>
            {
                if (isConnectedToInternet())
                {
                    var client = new JsonServiceClient(baseURL + URLItem);
                    SimpleDTO simpleDTO = new SimpleDTO()
                    {
                        Id = 50,
                        Name = "new item"
                    };
                    var response = await client.PostAsync(new PostSimpleDTO {
                        RequestDTO = simpleDTO
                    });
                    return response;
                }
                else
                {
                    await DisplayAlert("Connection lost", "Not connected to Internet", "OK");
                    return null;
                }
            });

            waiting.IsRunning = false;
        }
    }
}