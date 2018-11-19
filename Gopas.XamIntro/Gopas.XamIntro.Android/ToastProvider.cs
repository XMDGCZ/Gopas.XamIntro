using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Gopas.XamIntro.Course._5DependencyService;
using Gopas.XamIntro.Droid;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToastProvider))]
namespace Gopas.XamIntro.Droid
{
    class ToastProvider : IToastProvider
    {
        public void ShowToastMessge( string text)
        {
            Toast toast = Toast.MakeText(CrossCurrentActivity.Current.Activity, text, ToastLength.Long);
            toast.Show();
        }
    }
}