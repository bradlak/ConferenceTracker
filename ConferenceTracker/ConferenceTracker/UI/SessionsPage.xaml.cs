using ConferenceTracker.Infrastructure;
using ConferenceTracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ConferenceTracker.UI
{
    public partial class SessionsPage : TrackerContentPage<SessionsViewModel>
    {
        public SessionsPage()
        {
            InitializeComponent();
            ListView.ItemSelected += (s, e) => { ListView.SelectedItem = null; };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!ViewModel.Sessions.Any())
            {
                ViewModel.LoadSessionsCommand.Execute(null);
            }
        }
    }
}
