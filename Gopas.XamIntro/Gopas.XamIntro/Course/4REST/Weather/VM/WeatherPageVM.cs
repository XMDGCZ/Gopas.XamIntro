using Gopas.XamIntro.Course._4REST.Weather.DTOs;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Gopas.XamIntro.Course._4REST.Weather.VM
{
    class WeatherPageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ClickCommand { get; private set; }
        bool canClick = true;
        public bool CanClick
        {
            get { return canClick; }
            set
            {
                canClick = value;
                OnPropertyChanged("CanClick");
            }
        }
        private double _latitude;

        public double Latitude
        {
            get { return _latitude; }
            set {
                _latitude = value;
                OnPropertyChanged("Latitude");
            }
        }

        private double _longLatitude;

        public double LongLatitude
        {
            get { return _longLatitude; }
            set { _longLatitude = value;
                OnPropertyChanged("LongLatitude");
            }
        }

        private WeatherLocationDTO weatherDTO;

        public WeatherLocationDTO WeatherDTO
        {
            get { return weatherDTO; }
            set {
                weatherDTO = value;
                OnPropertyChanged("WeatherDTO");
            }
        }


        public WeatherPageVM()
        {
            ClickCommand = new Command( async () => await SetLocation(), () => CanClick );
    
        }

        private async Task SetLocation()
        {
                CanClick = false;

                var location = await LocationHelper.GetLocation();
                Latitude = location.Latitude;
                LongLatitude = location.Longitude;
                WeatherDTO = await WeatherHelper.GetCurrentConditionsAsync(Latitude, LongLatitude);
                
                CanClick = true;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
