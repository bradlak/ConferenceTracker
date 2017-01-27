using Custom = ConferenceTracker.UI;
using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace ConferenceTracker
{
    public partial class App : Application
    {
        public static IUnityContainer Container { get; set; }
        public App()
        {
            InitializeComponent();
            Container = Bootstrapper.Bootstrap();
            MainPage = Container.Resolve<Custom.MainPage>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
