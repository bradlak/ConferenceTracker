using ConferenceTracker.Services.Interfaces;
using Microsoft.Practices.Unity;
using Mock = ConferenceTracker.Services.Mock;
using ConferenceTracker.UI;
using ConferenceTracker.ViewModel;
using ConferenceTracker.UI.DetailsPages;
using ConferenceTracker.ViewModel.Details;
using ConferenceTracker.Services;
using ConferenceTracker.Configurations;
using ConferenceTracker.Infrastructure;

namespace ConferenceTracker
{
    public class Bootstrapper
    {
        public static IUnityContainer Bootstrap()
        {
            var container = new UnityContainer();

            // environment registration
            container.RegisterType<IApiConfiguration, ApiTestConfiguration>();

            container.RegisterType<IServiceCaller, ServiceCaller>();

            // services registrations
            container.RegisterType<ISponsorsService, Mock.SponsorsService>();
            container.RegisterType<ISpeakersService, SpeakersService>();
            container.RegisterType<ISessionsService, Mock.SessionsService>();
            container.RegisterType<IInfoService, Mock.InfoService>();
            container.RegisterType<IEventsService, EventsService>();

            // main view models & pages registrations
            container.RegisterType<SponsorsViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<EventsViewModel>();
            container.RegisterType<AboutViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<FeedsViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<NavigationViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<SessionsViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<SpeakersViewModel>(new ContainerControlledLifetimeManager());

            container.RegisterType<SponsorsPage>();
            container.RegisterType<EventsPage>();
            container.RegisterType<AboutPage>();
            container.RegisterType<FeedsPage>();
            container.RegisterType<NavPage>();
            container.RegisterType<SessionsPage>();

            // details view models & pages registrations
            container.RegisterType<SpeakerDetailsViewModel>();
            container.RegisterType<SpeakerDetails>();

            container.RegisterType<SessionDetailsViewModel>();
            container.RegisterType<SessionDetails>();


            // additional registrations
            container.RegisterType<MainPage>();
            return container;
        }
    }
}
