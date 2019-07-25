using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.Course._3Plugins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecureStoragePage : ContentPage
    {
        public string Key { get; set; }
        public string Value { get; set; }
        private string inforLabel;

        public string InfoLabel
        {
            get {
                if(string.IsNullOrEmpty(inforLabel)) return "Click on button";
                return inforLabel; }
            set { inforLabel = value;
                OnPropertyChanged();
            }
        }
        public Command SaveCommand { get; set; }
        public Command GetCommand { get; set; }
        public SecureStoragePage()
        {
            
            SaveCommand = new Command(async () =>
            {
                if (string.IsNullOrEmpty(Key) || string.IsNullOrEmpty(Value))
                {
                    InfoLabel = "Key or Value entries are empty";
                    return;
                }
                await SaveToSecureStorage(Key, Value);
            });
            GetCommand = new Command(async () =>
            {
                InfoLabel = await GetFromStorage(Key);
            });

            InitializeComponent();
        }

        async Task SaveToSecureStorage(string key, string value)
        {
            try
            {
                await SecureStorage.SetAsync(key, value);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        async Task<string> GetFromStorage(string key)
        {
            try
            {
                return await SecureStorage.GetAsync(key) ?? "key not found";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "error";
            }
        }
    }
}