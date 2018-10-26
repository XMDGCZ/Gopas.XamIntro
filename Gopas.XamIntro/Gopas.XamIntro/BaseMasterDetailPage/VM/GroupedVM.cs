using Gopas.XamIntro.BaseMasterDetailPage.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Gopas.XamIntro.BaseMasterDetailPage.VM
{
    class GroupedVM : ObservableCollection<MasterMenuItemVM>
    {
        public string ShortName { get; set; }
        public string LongName { get; set; }
    }
}
