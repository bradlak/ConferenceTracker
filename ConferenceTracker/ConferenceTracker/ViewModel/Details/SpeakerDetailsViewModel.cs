using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;

namespace ConferenceTracker.ViewModel.Details
{
    public class SpeakerDetailsViewModel : BaseViewModel
    {
        public SpeakerDetailsViewModel(
            IServiceCaller serviceCaller) : base(serviceCaller)
        {

        }

        private Speaker speaker;

        public Speaker Speaker
        {
            get
            {
                return speaker;
            }
            set
            {
                speaker = value;
                RaisePropertyChanged();
            }
        }
    }
}
