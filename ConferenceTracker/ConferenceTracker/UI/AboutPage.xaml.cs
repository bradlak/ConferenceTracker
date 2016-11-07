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
    public partial class AboutPage : TrackerContentPage<AboutViewModel>
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(ViewModel.Info == null)
            {
                ViewModel.LoadInfoCommand.Execute(null);
            }
        }
    }
}
