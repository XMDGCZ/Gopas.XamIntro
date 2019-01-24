using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Gopas.XamIntro.Course._4REST.ASPVM
{
    public class SimpleEntityM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private long _Id;
        private string _name;


        public SimpleEntityM(long id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public long Id
        {
            get { return _Id; }
            set {
                _Id = value;
                OnPropertyChanged();
            }
        }

       

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
