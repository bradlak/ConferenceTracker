using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace ConferenceTracker.Infrastructure
{
    public abstract class BaseViewModel : ViewModelBase
    {
        public INavigation Navigator { get; set; }

        private bool isBusy;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                RaisePropertyChanged();
            }
        }

        private bool refreshing;
        public bool Refreshing
        {
            get
            {
                return refreshing;
            }
            set
            {
                refreshing = value;
                RaisePropertyChanged();
            }
        }
    }
}
