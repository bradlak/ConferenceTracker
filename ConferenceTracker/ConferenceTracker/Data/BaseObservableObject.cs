using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConferenceTracker.Data
{
    public class BaseObservableObject : BaseObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaiseOnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
