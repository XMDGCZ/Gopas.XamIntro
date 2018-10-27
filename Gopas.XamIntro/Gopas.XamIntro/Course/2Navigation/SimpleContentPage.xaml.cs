using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.Course.GUIComponents._2Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleContentPage : ContentPage
    {
        public SimpleContentPage()
        {
            InitializeComponent();
        }

        private async void NavigateBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


    }
}