﻿using ConferenceTracker.Data;
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

        private ICommand refresh;

        public EventsViewModel(
            IEventsService service,
            IServiceCaller serviceCaller) : base(serviceCaller)
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
                loadEventsCommand = loadEventsCommand ?? new RelayCommand(async () => await LoadEventsAsync());
                return loadEventsCommand;
            }
        }

        public ICommand Refresh
        {
            get
            {
                refresh = refresh ?? new RelayCommand(async () => await LoadEventsAsync());
                return refresh;
            }
        }

        private async Task LoadEventsAsync()
        {
            IsBusy = true;

            var data = await ServiceCaller.CallService(service.GetAllEvents);

            if (data.IsSuccess)
            {
                Events = new ObservableCollection<Event>(data.Value);
            }

            IsBusy = false;
            Refreshing = false;
        }
    }
}
