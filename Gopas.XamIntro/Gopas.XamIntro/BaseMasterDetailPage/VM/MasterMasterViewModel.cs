using Gopas.XamIntro.BaseMasterDetailPage.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Gopas.XamIntro.BaseMasterDetailPage.VM
{
    class MasterMasterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<GroupedVM> MenuItems { get; set; } = new ObservableCollection<GroupedVM>();

        public MasterMasterViewModel()
        {

            var firstSection = new GroupedVM ()
            {
                ShortName = "Představení nástroje Xamarin",
                LongName = "Představení nástroje Xamarin",
                
            };
            firstSection.Add(new MasterMenuItemVM { Title = "Xamarin a jeho vnitřní fungování" });


            var secondSection = new GroupedVM()
            {
                ShortName = "Základní prvky GUI",
                LongName = "Základní prvky GUI",
                
            };
            secondSection.Add(new MasterMenuItemVM { Title = "Základní prvky" });
            secondSection.Add(new MasterMenuItemVM { Title = "Layouts" });


            MenuItems.Add(firstSection);
            MenuItems.Add(secondSection);
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
