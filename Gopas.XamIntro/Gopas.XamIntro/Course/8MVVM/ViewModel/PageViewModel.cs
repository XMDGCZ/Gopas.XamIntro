using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gopas.XamIntro.Course._8MVVM.ViewModel
{
    class PageViewModel : INotifyPropertyChanged
    {
        public string PageTitle { get; set; } = "Title from VM";
        private string labelValue = "Default Text";

        public string LabelValue
        {
            get {
                return labelValue;
            }
            set {
                labelValue = value;
                OnPropertyChanged("LabelValue");
            }
        }

        public ICommand ClickCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public PageViewModel()
        {
            ClickCommand = new Command<string>( ClickMethod );
        }

        void ClickMethod(string CommandParamater)
        {
            LabelValue = CommandParamater;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
