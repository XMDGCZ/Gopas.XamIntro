using Gopas.XamIntro.BaseMasterDetailPage.Pages;
using Gopas.XamIntro.Course._1GUIComponents;
using Gopas.XamIntro.Course.GUIComponents._2Navigation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Gopas.XamIntro.BaseMasterDetailPage.VM
{
    class MasterMasterVM : INotifyPropertyChanged
    {
        public ObservableCollection<GroupedVM> MenuItems { get; set; } = new ObservableCollection<GroupedVM>();
        public MasterMasterVM()
        {
            var section = new GroupedVM()
            {
                ShortName = "Základní prvky GUI",
                LongName = "Základní prvky GUI",
            };
            section.Add(new MasterMenuItemVM { Title = "Components", TargetType = typeof(FormsGUIComponentsPage) });
            section.Add(new MasterMenuItemVM { Title = "Layouts", TargetType = typeof(LayoutsPage) });

            MenuItems.Add(section);

            section = new GroupedVM()
            {
                ShortName = "Navigační stránky",
                LongName = "Navigační stránky",

            };
            section.Add(new MasterMenuItemVM { Title = "Jednoduchá navigace", TargetType = typeof(SimpleNavigationPage) });
            MenuItems.Add(section);

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
