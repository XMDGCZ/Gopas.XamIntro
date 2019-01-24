using SharedModel.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Gopas.XamIntro.Course._4REST.ServiceStack;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Gopas.XamIntro.Course._4REST.ASPVM;
using System.Diagnostics;

namespace Gopas.XamIntro.Course._4REST
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestASP : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<SimpleEntityM> _entities = new ObservableCollection<SimpleEntityM>();
        public ObservableCollection<SimpleEntityM> Entities
        {
            get
            {
                return _entities;
            }
            set
            {
                _entities = value;
                OnPropertyChanged();
            }
        }
        SimpleEntityM _selectedEntity;
        public SimpleEntityM SelectedEntity
        {
            get
            {
                return _selectedEntity;
            }
            set
            {
                _selectedEntity = value;   
            }
        }
        SimpleEntityDTOClient client = new SimpleEntityDTOClient();


        public RestASP()
        {
            this.BindingContext = this;
            
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
                Entities.Clear();
                var list = new ObservableCollection<SimpleEntityM>();
               // Entities.RaiseListChangedEvents = true;
                Entities = list;
                foreach(SimpleEntity simpleEntity in simpleEntities)
                {
                    list.Add(new SimpleEntityM(simpleEntity.Id, simpleEntity.Name));
                }
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
            bool isUpdated = false;

            if (SelectedEntity != null)
            {
                id = SelectedEntity.Id;
                name = nameEntry.Text;
                SelectedEntity.Name = name;
                isUpdated = true;
            }
            else
            {
                id = 0;
                name = nameEntry.Text;
            }

            var simpleEntityDTO = await client.CreateOrUpdate(id, name);

            if(simpleEntityDTO == null)
            {
                await DisplayAlert("Communication error", "Communication error", "OK");
            }

            if (!isUpdated)
            {
                Entities.Add(new SimpleEntityM(simpleEntityDTO.Id, simpleEntityDTO.Name));
            }
            waiting.IsRunning = false;
        }

        private async void DeleteButtonClicked(object sender, EventArgs e)
        {
            if (SelectedEntity == null) return;

            waiting.IsRunning = true;

            if (!await CheckConnection()) return;

            var response = await client.Delete(SelectedEntity.Id);
            if (response.Equals("ok"))
            {
                Entities.Remove(SelectedEntity);
            }
            else
            {
                Debug.WriteLine(response);
            }
            waiting.IsRunning = false;
        }
        
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            nameEntry.Text = SelectedEntity.Name;
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

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}