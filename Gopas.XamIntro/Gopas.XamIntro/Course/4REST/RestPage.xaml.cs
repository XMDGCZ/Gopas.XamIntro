using Gopas.XamIntro.Course._4REST.DTO;
using Newtonsoft.Json;
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
	public partial class RestPage : ContentPage
	{
        string apiUrl = "https://api.chucknorris.io/jokes/random?category=dev";

        public RestPage ()
		{
			InitializeComponent ();
		}

        private async void JokeButtonClicked(object sender, EventArgs e)
        {
            waiting.IsRunning = true;
            if (isConnectedToInternet())
            {
                HttpClient httpClient = new HttpClient();
                var uri = new Uri(string.Format(apiUrl, string.Empty));
                var response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var dataFromApi = JsonConvert.DeserializeObject<ChuckNorrisJokeDTO>(content);
                    if (!string.IsNullOrEmpty(dataFromApi.value))
                    {
                        await DisplayAlert("Joke", dataFromApi.value, "OK");
                    }
                    else
                    {
                        await DisplayAlert("Nope", "Chuck Norris makes no jokes", "OK");
                    }
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