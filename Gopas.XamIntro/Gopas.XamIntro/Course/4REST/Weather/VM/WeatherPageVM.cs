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

        bool isLoading = false;
        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;
                OnPropertyChanged("IsLoading");
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

        private string weatherDescription;
        public string WeatherDescription
        {
            get {
               
                if (!string.IsNullOrEmpty(weatherDescription)) return weatherDescription;
                else return "Weather not found";

            }
            set {
                weatherDescription = value;
                OnPropertyChanged("WeatherDescription");
            }
        }


        public WeatherPageVM()
        {
            ClickCommand = new Command( async () => await SetLocation(), () => CanClick );
    
        }

        private async Task SetLocation()
        {
            CanClick = false;
            IsLoading = true;

            var location = await LocationHelper.GetLocation();
            Latitude = location.Latitude;
            LongLatitude = location.Longitude;
            var weather = await WeatherHelper.GetCurrentConditionsAsync(Latitude, LongLatitude);
            WeatherDescription = weather.list?[0].weather?[0].description;

            CanClick = true;
            IsLoading = false;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
