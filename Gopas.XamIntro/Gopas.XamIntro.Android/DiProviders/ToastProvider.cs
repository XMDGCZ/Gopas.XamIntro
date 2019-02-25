using Android.Widget;
using Gopas.XamIntro.Course._5DependencyService;
using Gopas.XamIntro.Droid.DIProviders;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToastProvider))]
namespace Gopas.XamIntro.Droid.DIProviders
{
    class ToastProvider : IToastProvider
    {
        public void ShowToastMessge( string text)
        {
            Toast toast = Toast.MakeText(Android.App.Application.Context, text, ToastLength.Long);
            toast.Show();
        }
    }
}