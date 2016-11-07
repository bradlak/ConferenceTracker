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
    public partial class SpeakerDetails : TrackerContentPage<SpeakerDetailsViewModel>
    {
        public SpeakerDetails()
        {
            InitializeComponent();
            var tapRecognizer = new TapGestureRecognizer();
            tapRecognizer.Tapped += (s, e) =>
            {
                var uri = new Uri(((Label)s).Text);
                Device.OpenUri(uri);
            };

            fbLabel.GestureRecognizers.Add(tapRecognizer);
            twLabel.GestureRecognizers.Add(tapRecognizer);
            ghLabel.GestureRecognizers.Add(tapRecognizer);

            if(Device.OS == TargetPlatform.iOS)
            {
                tableView.RowHeight = 300;
            }
        }
    }
}
