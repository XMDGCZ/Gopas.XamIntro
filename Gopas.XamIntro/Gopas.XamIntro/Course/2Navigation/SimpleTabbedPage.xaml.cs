using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.Course._2Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleTabbedPage : TabbedPage
    {
        public SimpleTabbedPage ()
        {
            InitializeComponent();
        }
    }
}