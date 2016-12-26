using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;
using ConferenceTracker.Services.Interfaces;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConferenceTracker.ViewModel
{
    public class SponsorsViewModel : BaseViewModel
    {
        private ISponsorsService service;

        private ObservableCollection<Sponsor> sponsors;

        private ICommand loadSponsorsCommand;

        public ObservableCollection<Sponsor> Sponsors
        {
            get { return sponsors; }
            set
            {
                sponsors = value;
                RaisePropertyChanged();
            }
        }

        public SponsorsViewModel(
            ISponsorsService service,
            IServiceCaller serviceCaller) : base(serviceCaller)
        {
            this.service = service;
            Sponsors = new ObservableCollection<Sponsor>();
        }

        public ICommand LoadSponsorsCommand
        {
            get
            {
                if(loadSponsorsCommand == null)
                {
                    loadSponsorsCommand = new RelayCommand(async () => await LoadSponsorsAsync());
                }
                return loadSponsorsCommand;
            }
        }

        public async Task LoadSponsorsAsync()
        {
            IsBusy = true;

            Sponsors = new ObservableCollection<Sponsor>(await service.GetAllSponsors());
            await Task.Delay(2000);

            IsBusy = false;
        }
    }
}
