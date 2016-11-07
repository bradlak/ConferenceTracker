using ConferenceTracker.Infrastructure;
using ConferenceTracker.Services.Mock;
using ConferenceTracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ConferenceTracker.UI
{
    public partial class SponsorsPage : TrackerContentPage<SponsorsViewModel>
    {
        public SponsorsPage()
        {
            InitializeComponent();
            ListView.ItemSelected += (s, e) => { ListView.SelectedItem = null; };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!ViewModel.Sponsors.Any())
            {
                ViewModel.LoadSponsorsCommand.Execute(null);
            }
        }
    }
}
