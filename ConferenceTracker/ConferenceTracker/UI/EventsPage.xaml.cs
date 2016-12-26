using ConferenceTracker.Infrastructure;
using ConferenceTracker.Services;
using ConferenceTracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ConferenceTracker.UI
{
    public partial class EventsPage : TrackerContentPage<EventsViewModel>
    {
        public EventsPage()
        {
            InitializeComponent();
            ListView.ItemSelected += (s, e) => { ListView.SelectedItem = null; };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!ViewModel.Events.Any())
            {
                ViewModel.LoadEventsCommand.Execute(null);
            }
        }
    }
}
