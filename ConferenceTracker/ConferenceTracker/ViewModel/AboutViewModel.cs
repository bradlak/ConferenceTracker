using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;
using ConferenceTracker.Services.Interfaces;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConferenceTracker.ViewModel
{
    public class AboutViewModel : BaseViewModel
    {
        private IInfoService service;

        private ConferenceInfo info;

        private ICommand loadInfoCommand;

        public AboutViewModel(
            IInfoService service,
            IServiceCaller serviceCaller) : base(serviceCaller)
        {
            this.service = service;
        }

        public ConferenceInfo Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
                RaisePropertyChanged();
            }
        }

        public ICommand LoadInfoCommand
        {
            get
            {
                loadInfoCommand = loadInfoCommand ?? new RelayCommand(async () => await LoadInfo());
                return loadInfoCommand;
            }
        }

        private async Task LoadInfo()
        {
            IsBusy = true;

            await Task.Delay(1000);

            Info = await service.GetInfo();

            IsBusy = false;
            Refreshing = false;
        }
    }
}
