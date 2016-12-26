using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;
using GalaSoft.MvvmLight.Command;
using System.Linq;
using System.Windows.Input;

namespace ConferenceTracker.ViewModel.Details
{
    public class SessionDetailsViewModel : BaseViewModel
    {
        public SessionsViewModel ParentViewModel { get; set; }

        private Session session;

        private ICommand toggleFavouriteCommand;


        public SessionDetailsViewModel(
            IServiceCaller serviceCaller) : base(serviceCaller)
        {

        }

        public Session Session
        {
            get
            {
                return session;
            }
            set
            {
                session = value;
                RaisePropertyChanged();
            }
        }

        public ICommand ToggleFavouriteCommand
        {
            get
            {
                return toggleFavouriteCommand ?? (new RelayCommand<int>((i) => ToggleFavourite(i)));
            }
        }

        private void ToggleFavourite(int id)
        {
            ParentViewModel.ToggleFavourite(id);
            if (ParentViewModel.Navigator.NavigationStack.Any())
            {
                ParentViewModel.Navigator.PopToRootAsync();
            }
        }
    }
}
