using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;
using ConferenceTracker.Services.Interfaces;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConferenceTracker.ViewModel
{
    public class EventsViewModel : BaseViewModel
    {
        private IEventsService service;

        private ObservableCollection<Event> events;

        private ICommand loadEventsCommand;

        public EventsViewModel(IEventsService service)
        {
            this.service = service;
            Events = new ObservableCollection<Event>();
        }

        public ObservableCollection<Event> Events
        {
            get
            {
                return events;
            }
            set
            {
                events = value;
                RaisePropertyChanged();
            }
        }

        public ICommand LoadEventsCommand
        {
            get
            {
                loadEventsCommand = loadEventsCommand ?? new RelayCommand(async () => await LoadEvents());
                return loadEventsCommand;
            }
        }

        private async Task LoadEvents()
        {
            IsBusy = true;

            await Task.Delay(2000);

            Events = new ObservableCollection<Event>(await service.GetAllEvents());

            IsBusy = false;
            Refreshing = false;
        }
    }
}
