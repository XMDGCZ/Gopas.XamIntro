using Gopas.XamIntro.Course._7Database.SQLite.Entity;
using Newtonsoft.Json;
using ServiceStack;
using SharedModel;
using SharedModel.Entity;
using SharedModel.ServiceStackFolderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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

                /*
                HttpClient httpClient = new HttpClient();
                var uri = new Uri(string.Format(getAllItemsUrl, string.Empty));
                var response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var dataFromApi = JsonConvert.DeserializeObject<List<ASPItem>>(content);
                    if (dataFromApi?.Count != 0)
                    {
                        listView.ItemsSource = dataFromApi;
                    }
                    else
                    {
                        await DisplayAlert("Error","No data to display","Ok");
                    }
                }*/
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