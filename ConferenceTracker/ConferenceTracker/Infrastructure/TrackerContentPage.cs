using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace ConferenceTracker.Infrastructure
{
    public class TrackerContentPage<T> : ContentPage where T : BaseViewModel
    {
        private readonly T viewModel;

        public T ViewModel
        {
            get { return viewModel; }
        }

        public TrackerContentPage()
        {
            viewModel = App.Container.Resolve<T>();
            viewModel.Navigator = Navigation;
            BindingContext = viewModel;
            if (ViewModel.ShouldSubscribe) ViewModel.SubscribeMessages();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ViewModel.Dispose();
        }
    }
}
