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
                loadInfoCommand = loadInfoCommand ?? new RelayCommand(async () => await LoadInfoAsync());
                return loadInfoCommand;
            }
        }

        private async Task LoadInfoAsync()
        {
            IsBusy = true;

            var data = await ServiceCaller.CallService(service.GetInfo);
            if (data.IsSuccess)
            {
                Info = data.Value;
            }

            IsBusy = false;
            Refreshing = false;
        }
    }
}
