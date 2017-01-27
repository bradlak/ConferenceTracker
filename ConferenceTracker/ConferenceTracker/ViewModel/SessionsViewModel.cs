using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;
using ConferenceTracker.Services.Interfaces;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.Unity;
using System.Threading.Tasks;
using System.Windows.Input;
using ConferenceTracker.UI.DetailsPages;

namespace ConferenceTracker.ViewModel
{
    public class SessionsViewModel : BaseViewModel
    {
        private ISessionsService service;

        private ObservableCollection<Session> sessions;

        private Session selectedSession;

        private IList<Session> allSessions;

        private ICommand loadSessionsCommand;

        private ICommand searchCommand;

        private ICommand refresh;

        private string searchText;

        public ObservableCollection<Session> Sessions
        {
            get
            {
                return sessions;
            }
            set
            {
                sessions = value;
                RaisePropertyChanged();
            }
        }

        public Session SelectedSession
        {
            get
            {
                return selectedSession;
            }
            set
            {
                selectedSession = value;
                if (selectedSession != null)
                {
                    ShowDetails();
                }
            }
        }

        public SessionsViewModel(
            ISessionsService service,
            IServiceCaller serviceCaller) : base(serviceCaller)
        {
            this.service = service;
            Sessions = new ObservableCollection<Session>();
            allSessions = new List<Session>();
        }

        public ICommand LoadSessionsCommand
        {
            get
            {
                loadSessionsCommand = loadSessionsCommand ?? new RelayCommand(async () => await LoadSessionsAsync());
                return loadSessionsCommand;
            }
        }

        public ICommand Refresh
        {
            get
            {
                refresh = refresh ?? new RelayCommand(async () => await LoadSessionsAsync());
                return refresh;
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                searchCommand = searchCommand ?? new RelayCommand(() => FilterSessions(), () => { return !IsBusy; });
                return searchCommand;
            }
        }

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                SearchCommand.Execute(null);
                RaisePropertyChanged();
            }
        }

        private void FilterSessions()
        {
            var filtered = allSessions.Where(z => z.Title.ToLower().Contains(SearchText.ToLower())).ToList();
            if (string.IsNullOrEmpty(SearchText))
            {
                Sessions = new ObservableCollection<Session>(allSessions);
            }
            else
                Sessions = new ObservableCollection<Session>(filtered);
        }

        public async Task LoadSessionsAsync()
        {
            IsBusy = true;

            var data = await ServiceCaller.CallService(service.GetAllSessions);

            if (data.IsSuccess)
            {
                Sessions = new ObservableCollection<Session>(data.Value);
                allSessions = new List<Session>(Sessions.ToList());
            }

            IsBusy = false;
            Refreshing = false;
        }

        public void ToggleFavourite(int id)
        {
            var favourite = Sessions.Single(z => z.Id == id).IsFavourite;
            Sessions.Single(z => z.Id == id).IsFavourite = !favourite;
            // TO DO - call service - save favourite for user
            Sessions = new ObservableCollection<Session>(Sessions);
        }

        public void ShowDetails()
        {
            var page = App.Container.Resolve<SessionDetails>();
            page.ViewModel.Session = SelectedSession;
            page.ViewModel.ParentViewModel = this;
            Navigator.PushAsync(page);
        }
    }
}
