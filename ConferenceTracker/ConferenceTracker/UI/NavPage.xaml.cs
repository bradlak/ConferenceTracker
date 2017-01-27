using ConferenceTracker.Infrastructure;
using ConferenceTracker.ViewModel;

namespace ConferenceTracker.UI
{
    public partial class NavPage : TrackerContentPage<NavigationViewModel>
    {
        public NavPage()
        {
            InitializeComponent();
            listView.ItemSelected += (s, e) =>
            {
                listView.SelectedItem = null;
            };
        }
    }
}
