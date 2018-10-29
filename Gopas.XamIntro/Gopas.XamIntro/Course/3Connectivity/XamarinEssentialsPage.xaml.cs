using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.Course._3Connectivity
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class XamarinEssentialsPage : ContentPage
	{
		public XamarinEssentialsPage ()
		{
			InitializeComponent ();
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        private void CheckConnectivityClick(object sender, EventArgs e)
        {
            var networkAccess = Connectivity.NetworkAccess;
            var profiles = Connectivity.Profiles;
            DisplayConnectivityStatus(networkAccess, profiles);
        }

        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var networkAccess = e.NetworkAccess;
            var profiles = e.Profiles;
            DisplayConnectivityStatus(networkAccess, profiles);
        }

        void DisplayConnectivityStatus(NetworkAccess networkAccess, IEnumerable<ConnectionProfile> profiles)
        {
            if (networkAccess == NetworkAccess.Internet)
            {
                DisplayAlert("Connectivity status",
                "Connected to Internet via: " + string.Join<ConnectionProfile>(" ", profiles)
                , "OK");
            }
            else if(networkAccess == NetworkAccess.None)
            {
                DisplayAlert("Connection lost",
                "Not connected to Internet"
                , "OK");
            }
        }
    }
}