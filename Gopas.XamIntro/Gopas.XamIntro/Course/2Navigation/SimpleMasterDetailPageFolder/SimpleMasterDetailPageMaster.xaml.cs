using Gopas.XamIntro.Course._2Navigation.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.Course._2Navigation.SimpleMasterDetailPageFolder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public SimpleMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new SimpleMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class SimpleMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<SimpleMasterDetailPageMenuItem> MenuItems { get; set; }
            
            public SimpleMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<SimpleMasterDetailPageMenuItem>(new[]
                {
                    new SimpleMasterDetailPageMenuItem { Title="Content Page #1", TargetType = typeof(SimpleContentPage) },
                    new SimpleMasterDetailPageMenuItem { Title="Content Page #2", TargetType = typeof(SimpleContentPage2) },
                    new SimpleMasterDetailPageMenuItem { Title="Content Page #3", TargetType = typeof(SimpleContentPage3) },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}