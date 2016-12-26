using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;
using ConferenceTracker.Services.Interfaces;
using ConferenceTracker.UI.DetailsPages;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.Unity;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConferenceTracker.ViewModel
{
    public class SpeakersViewModel : BaseViewModel
    {
        private ISpeakersService service;

        private ObservableCollection<Speaker> speakers;

        private ICommand loadSpeakersCommand;

        private ICommand refresh;

        private Speaker selectedSpeaker;

        public ObservableCollection<Speaker> Speakers
        {
            get
            {
                return speakers;
            }
            set
            {
                speakers = value;
                RaisePropertyChanged();
            }
        }

        public SpeakersViewModel(
            ISpeakersService service,
            IServiceCaller serviceCaller) : base(serviceCaller)
        {
            this.service = service;
            Speakers = new ObservableCollection<Speaker>();
        }

        public ICommand LoadSpeakersCommand
        {
            get
            {
                loadSpeakersCommand = loadSpeakersCommand ?? new RelayCommand(async () => await LoadSpeakersAsync());
                return loadSpeakersCommand;
            }
        }

        public ICommand Refresh
        {
            get
            {
                refresh = refresh ?? new RelayCommand(async () => await RefreshSpeakersAsync());
                return refresh;
            }
        }

        public Speaker SelectedSpeaker
        {
            get
            {
                return selectedSpeaker;
            }
            set
            {
                selectedSpeaker = value;
                if(selectedSpeaker != null)
                {
                    ShowDetails();
                }
            }
        }

        public async Task LoadSpeakersAsync()
        {
            IsBusy = true;

            var data = await ServiceCaller.CallService(service.GetAllSpeakers);

            if (data.IsSuccess)
            {
                Speakers = new ObservableCollection<Speaker>(data.Value);
            }

            IsBusy = false;
            Refreshing = false;
        }

        public async Task RefreshSpeakersAsync()
        {
            var data = await ServiceCaller.CallService(service.GetAllSpeakers);

            if (data.IsSuccess)
            {
                Speakers = new ObservableCollection<Speaker>(data.Value);
            }

            Refreshing = false;
        }

        public void ShowDetails()
        {
            var page = App.Container.Resolve<SpeakerDetails>();
            page.ViewModel.Speaker = SelectedSpeaker;
            Navigator.PushAsync(page);
        }
    }
}
