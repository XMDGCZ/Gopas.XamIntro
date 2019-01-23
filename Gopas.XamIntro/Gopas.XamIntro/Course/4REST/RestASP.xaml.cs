using ServiceStack;
using SharedModel.Entity;
using SharedModel.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Web;

namespace Gopas.XamIntro.Course._4REST
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestASP : ContentPage
    {
        const string baseURL = "http://10.0.2.2:5080/api/";
        SimpleEntity selectedEntity;

        public RestASP()
        {
            InitializeComponent();
           // queryString["name"] = "default item";
        }
               
        private async void getAllButtonClicked(object sender, EventArgs e)
        {
            waiting.IsRunning = true;
            var items = await Task.Run<List<SimpleEntity>>( async () =>
            {
                if (isConnectedToInternet())
                {
                    var client = new JsonServiceClient(baseURL);
                    List<SimpleEntity> response = await client.GetAsync(new GetSimpleEntityDTO());
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

        private async void getByNameButtonClicked(object sender, EventArgs e)
        {
            waiting.IsRunning = true;
            var items = await Task.Run<List<SimpleEntity>>(async () =>
            {
                if (isConnectedToInternet())
                {
                    var client = new JsonServiceClient(baseURL);
                    List<SimpleEntity> response = await client.GetAsync(new GetSimpleEntityDTO()
                    {
                        Name = "default item"
                    });
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
            var items = await Task.Run<SimpleEntity>(async () =>
            {
                if (isConnectedToInternet())
                {
                    var client = new JsonServiceClient(baseURL);

                    SimpleEntity simpleDTO = new SimpleEntity()
                    {
                        Id = 50,
                        Name = "new item"
                    };
                    try
                    {
                        var response = await client.PostAsync(new PostSimpleEntityDTO
                        {
                            SimpleDTOContent = simpleDTO
                        });
                        return response;
                    }
                    catch (WebServiceException webEx)
                    {

                        return null;
                    }
                    
                }
                else
                {
                    await DisplayAlert("Connection lost", "Not connected to Internet", "OK");
                    return null;
                }
            });

            waiting.IsRunning = false;
        }

        private async void AddOrUpdateButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameEntry.Text)) return;

            waiting.IsRunning = true;
            var items = await Task.Run<SimpleEntity>(async () =>
            {
                if (isConnectedToInternet())
                {
                    var client = new JsonServiceClient(baseURL);
                    SimpleEntity simpleDTO = new SimpleEntity();

                    if (selectedEntity != null)
                    {
                        simpleDTO.Id = 2;
                        simpleDTO.Name = "asdasd";

                        try
                        {
                            var response = await client.PutAsync(new PostSimpleEntityDTO
                            {
                                SimpleDTOContent = simpleDTO
                            });
                            return response;
                        }
                        catch (WebServiceException webEx)
                        {

                            return null;
                        }
                    }
                    else
                    {

                        simpleDTO.Id = 0;
                        simpleDTO.Name = nameEntry.Text;

                        try
                        {
                            var response = await client.PostAsync(new PostSimpleEntityDTO
                            {
                                SimpleDTOContent = simpleDTO
                            });
                            return response;
                        }
                        catch (WebServiceException webEx)
                        {

                            return null;
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Connection lost", "Not connected to Internet", "OK");
                    return null;
                }
            });

            waiting.IsRunning = false;
        }

        private async void deleteButtonClicked(object sender, EventArgs e)
        {
            if (selectedEntity == null) return;
            waiting.IsRunning = true;
            var items = await Task.Run<string>(async () =>
            {
                if (isConnectedToInternet())
                {
                    var client = new JsonServiceClient(baseURL);
                    var response = await client.DeleteAsync(new DeleteSimpleEntityDTO
                    {
                        ID = selectedEntity.Id
                    });
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

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedEntity = (SimpleEntity) ((ListView)sender).SelectedItem;
            nameEntry.Text = selectedEntity.Name;
        }
    }
}