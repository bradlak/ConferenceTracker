using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;

namespace ConferenceTracker.ViewModel.Details
{
    public class SpeakerDetailsViewModel : BaseViewModel
    {
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
