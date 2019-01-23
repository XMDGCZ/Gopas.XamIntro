using SharedModel.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Gopas.XamIntro.Course._4REST.ServiceStack;

namespace Gopas.XamIntro.Course._4REST
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestASP : ContentPage
    {
        public ObservableCollection<SimpleEntity> Entities { get; set; }
        SimpleEntity selectedEntity;
        SimpleEntityClient client = new SimpleEntityClient();


        public RestASP()
        {
            InitializeComponent();
        }
               
        private async void GetAllButtonClicked(object sender, EventArgs e)
        {
            waiting.IsRunning = true;
            if (!await CheckConnection()) return;

            var response = await client.Get();
            DisplaySimpleEntities(response);

            waiting.IsRunning = false;
        }

        private async void GetByNameButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameEntry.Text)) return;
            waiting.IsRunning = true;

            if (!await CheckConnection()) return;

            var response = await client.Get(nameEntry.Text);
            DisplaySimpleEntities(response);

            waiting.IsRunning = false;
        }

 
        private async void DisplaySimpleEntities(List<SimpleEntity> simpleEntities)
        {
            if (simpleEntities.Count > 0)
            {
                Entities = new ObservableCollection<SimpleEntity>(simpleEntities);
                listView.ItemsSource = Entities;
            }
            else
            {
                await DisplayAlert("No data from API", "No data from API", "OK");
            }
        }

        private async void AddOrUpdateButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameEntry.Text)) return;
            waiting.IsRunning = true;

            if (!await CheckConnection()) return;

            long id;
            string name;

            if (selectedEntity != null)
            {
                id = selectedEntity.Id;
                name = nameEntry.Text;
            }
            else
            {
                id = 0;
                name = nameEntry.Text;
            }

            var simpleDTO = await client.CreateOrUpdate(id, name);
            if(simpleDTO == null)
            {
                await DisplayAlert("Communication error", "Communication error", "OK");
            }

            waiting.IsRunning = false;
        }

        private async void DeleteButtonClicked(object sender, EventArgs e)
        {
            if (selectedEntity == null) return;

            waiting.IsRunning = true;

            if (!await CheckConnection()) return;

            client.Delete(selectedEntity.Id);
            waiting.IsRunning = false;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedEntity = (SimpleEntity) ((ListView)sender).SelectedItem;
            nameEntry.Text = selectedEntity.Name;
        }

        private async Task<bool> CheckConnection()
        {
            if (!await APIClient.IsNetworkAccess())
            {
                await DisplayAlert("Connection lost", "Not connected to Internet", "OK");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}