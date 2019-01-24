using SharedModel.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Gopas.XamIntro.Course._4REST
{
    public class SimpleDTOVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private long _Id;

        public long Id
        {
            get { return _Id; }
            set {
                _Id = value;
                OnPropertyChanged();
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set {
                _name = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
