using ConferenceTracker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
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
