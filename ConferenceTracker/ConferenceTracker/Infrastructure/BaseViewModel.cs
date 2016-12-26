using System;
using ConferenceTracker.Messages;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace ConferenceTracker.Infrastructure
{
    public abstract class BaseViewModel : ViewModelBase
    {
        public INavigation Navigator { get; set; }

        protected IServiceCaller ServiceCaller { get; set; }

        public BaseViewModel(IServiceCaller serviceCaller)
        {
            ServiceCaller = serviceCaller;
            MessagingCenter.Subscribe<ServiceCaller>(this, MessagesConsts.NoInternet, NoInternetHandler);
            MessagingCenter.Subscribe<ServiceCaller>(this, MessagesConsts.ApiCallingError, ApiCallingErrorHandler);
        }

        public void Dispose()
        {
            MessagingCenter.Unsubscribe<ServiceCaller>(this, MessagesConsts.NoInternet);
            MessagingCenter.Unsubscribe<ServiceCaller>(this, MessagesConsts.ApiCallingError);
        }

        private void ApiCallingErrorHandler(ServiceCaller obj)
        {
            App.Current.MainPage.DisplayAlert("Api call error", "No internet access", "Cancel");
        }

        private void NoInternetHandler(ServiceCaller obj)
        {
            App.Current.MainPage.DisplayAlert("Error", "No internet access", "Cancel");
        }

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
