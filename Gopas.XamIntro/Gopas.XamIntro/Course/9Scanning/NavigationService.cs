using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Gopas.XamIntro.Course._9Scanning
{
    class NavigationService
    {
        public static INavigation GetNavigation()
        {
            return Application.Current.MainPage.Navigation;
        }
    }
}
