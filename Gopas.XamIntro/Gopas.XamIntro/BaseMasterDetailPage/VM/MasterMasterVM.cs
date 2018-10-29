using Gopas.XamIntro.BaseMasterDetailPage.Pages;
using Gopas.XamIntro.Course._1GUIComponents;
using Gopas.XamIntro.Course._2Navigation;
using Gopas.XamIntro.Course._2Navigation.SimpleMasterDetailPageFolder;
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
            section.Add(new MasterMenuItemVM { Title = "Absolute and Relative Layouts", TargetType = typeof(AbsoluteAndRelativeLayout) });
            section.Add(new MasterMenuItemVM { Title = "Flex Layout", TargetType = typeof(FlexLayoutPage) });

            MenuItems.Add(section);

            section = new GroupedVM()
            {
                ShortName = "Navigation",
                LongName = "Navigation"
            };
            section.Add(new MasterMenuItemVM { Title = "NavigationPage", TargetType = typeof(SimpleNavigationPage) });
            section.Add(new MasterMenuItemVM { Title = "TabbedPage", TargetType = typeof(SimpleTabbedPage) });
            section.Add(new MasterMenuItemVM { Title = "MasterDetailPage", TargetType = typeof(SimpleMasterDetailPage) });
            section.Add(new MasterMenuItemVM { Title = "CarouselPage", TargetType = typeof(SimpleCarouselPage) });
            section.Add(new MasterMenuItemVM { Title = "Alert", TargetType = typeof(SimpleAlertPage) });
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
