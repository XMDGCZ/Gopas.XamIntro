using Gopas.XamIntro.BaseMasterDetailPage.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.BaseMasterDetailPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage
    {
        public Master()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterMenuItemVM;
            if (item == null)
                return;
            if (item.TargetType != null)
            {
                try
                {             
                    var page = (Page)Activator.CreateInstance(item.TargetType);
                    page.Title = item.Title;

                    Detail = new NavigationPage(page);
                    IsPresented = false;
                }
                catch (TargetInvocationException  exception)
                {
                    Debug.WriteLine(exception.InnerException.ToString());
                }
            }
            else
            {
                Debug.WriteLine("Could not navigate, target type is null");
            }
            MasterPage.ListView.SelectedItem = null;
        }
    }
}