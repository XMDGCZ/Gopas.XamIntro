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
                ShortName = "Basic GUI components",
                LongName = "Basic GUI components",
            };
            section.Add(new MasterMenuItemVM { Title = "Components", TargetType = typeof(FormsGUIComponentsPage) });
            section.Add(new MasterMenuItemVM { Title = "StackLayout and Grid", TargetType = typeof(StackAndGridPage) });
            section.Add(new MasterMenuItemVM { Title = "Absolute and Relative layout", TargetType = typeof(AbsoluteAndRelativeLayout) });

            MenuItems.Add(section);

            section = new GroupedVM()
            {
                ShortName = "Navigation",
                LongName = "Navigation"
            };
            section.Add(new MasterMenuItemVM { Title = "Simple navigation", TargetType = typeof(SimpleNavigationPage) });
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
