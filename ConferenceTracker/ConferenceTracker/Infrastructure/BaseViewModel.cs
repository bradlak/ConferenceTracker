using System;
using ConferenceTracker.Messages;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace ConferenceTracker.Infrastructure
{
    public abstract class BaseViewModel : ViewModelBase
    {
        public bool ShouldSubscribe { get; set; }

        public INavigation Navigator { get; set; }

        protected IServiceCaller ServiceCaller { get; set; }

        public BaseViewModel(IServiceCaller serviceCaller, bool shouldSubscribeMessages = true)
        {
            ServiceCaller = serviceCaller;
            ShouldSubscribe = shouldSubscribeMessages;
        }

        public void SubscribeMessages()
        {
            MessagingCenter.Subscribe<ServiceCaller>(this, MessagesConsts.NoInternet, NoInternetHandler);
            MessagingCenter.Subscribe<ServiceCaller, Exception>(this, MessagesConsts.ApiCallingError, ApiCallingErrorHandler);
        }

        public void Dispose()
        {
            MessagingCenter.Unsubscribe<ServiceCaller>(this, MessagesConsts.NoInternet);
            MessagingCenter.Unsubscribe<ServiceCaller,Exception>(this, MessagesConsts.ApiCallingError);
        }

        private void NoInternetHandler(ServiceCaller obj)
        {
            App.Current.MainPage.DisplayAlert("Error", "No internet access", "Cancel");
        }

        private void ApiCallingErrorHandler(ServiceCaller obj, Exception ex)
        {
#if DEBUG
            App.Current.MainPage.DisplayAlert("Api call error", ex.Message, "Cancel");
#else
            App.Current.MainPage.DisplayAlert("Error", "Something went wrong. Try again later.", "Cancel");
#endif
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
