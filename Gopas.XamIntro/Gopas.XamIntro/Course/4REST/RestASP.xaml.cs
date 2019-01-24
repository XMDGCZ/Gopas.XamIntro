using SharedModel.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Gopas.XamIntro.Course._4REST.ServiceStack;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Gopas.XamIntro.Course._4REST
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestASP : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<SimpleDTOVM> _entities = new ObservableCollection<SimpleDTOVM>();
        public ObservableCollection<SimpleDTOVM> Entities
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
        SimpleDTOVM _selectedEntity;
        public SimpleDTOVM SelectedEntity
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
        SimpleEntityClient client = new SimpleEntityClient();


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
                var list = new ObservableCollection<SimpleDTOVM>();
               // Entities.RaiseListChangedEvents = true;
                Entities = list;
                foreach(SimpleEntity simpleEntity in simpleEntities)
                {
                    list.Add(new SimpleDTOVM
                    {
                        Id = simpleEntity.Id,
                        Name = simpleEntity.Name
                    });
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

            var simpleDTO = await client.CreateOrUpdate(id, name);

            if(simpleDTO == null)
            {
                await DisplayAlert("Communication error", "Communication error", "OK");
            }

            if (!isUpdated)
            {
                Entities.Add(new SimpleDTOVM
                {
                    Id = simpleDTO.Id,
                    Name = simpleDTO.Name
                });
            }
            waiting.IsRunning = false;
        }

        private async void DeleteButtonClicked(object sender, EventArgs e)
        {
            if (SelectedEntity == null) return;

            waiting.IsRunning = true;

            if (!await CheckConnection()) return;

            client.Delete(SelectedEntity.Id);
            Entities.Remove(SelectedEntity);
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

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}