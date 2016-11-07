using ConferenceTracker.Infrastructure;
using ConferenceTracker.ViewModel.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ConferenceTracker.UI.DetailsPages
{
    public partial class SessionDetails : TrackerContentPage<SessionDetailsViewModel>
    {
        public SessionDetails()
        {
            InitializeComponent();
            speakersList.ItemSelected += (s, e) => { speakersList.SelectedItem = null; };

            if (Device.OS == TargetPlatform.iOS)
            {
                tableView.RowHeight = 300;
            }
        }
    }
}
