using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gopas.XamIntro.BaseMasterDetailPage.Pages
{

    public class MasterMenuItemVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; }
        public MasterMenuItemVM()
        {
           
        }
        public MasterMenuItemVM(int Id, string Title, Type TargetType)
        {
            this.Id = Id;
            this.Title = Title;
            this.TargetType = TargetType;
        }

    }
}