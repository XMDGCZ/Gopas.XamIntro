using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gopas.XamIntro.Course._1GUIComponents
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormsGUIComponentsPage : ContentPage
	{
		public FormsGUIComponentsPage ()
		{
			InitializeComponent ();
            this.BindingContext = this;
		}
        public ICommand ClickCommand => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });
    }
}