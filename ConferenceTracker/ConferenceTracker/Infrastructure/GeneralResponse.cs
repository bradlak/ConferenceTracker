namespace ConferenceTracker.Infrastructure
{
    public class GeneralResponse<TResult>
    { 
        public bool IsSuccess { get; set; }

        public TResult Value { get; set; }
    }
}
