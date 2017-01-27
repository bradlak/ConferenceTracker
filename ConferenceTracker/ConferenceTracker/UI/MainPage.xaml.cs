
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Messaging;
using ConferenceTracker.Infrastructure;

namespace ConferenceTracker.UI
{
    public partial class MainPage : MasterDetailPage
    {
        NavPage masterPage;
        public MainPage()
        {
            masterPage = App.Container.Resolve<NavPage>();
            Master = masterPage;
            Detail = new NavigationPage(App.Container.Resolve<FeedsPage>());
            
            Messenger.Default.Register<ChangePageMessage>(this, ChangePageHandler);
        }

        private void ChangePageHandler(ChangePageMessage obj)
        {
            if(obj != null)
            {
                Detail = new NavigationPage((Page)App.Container.Resolve(obj.SelectedItem.TargetType, null));
                IsPresented = false;
            }
        }
    }
}
