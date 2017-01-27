namespace ConferenceTracker.Configurations
{
    public class ApiReleaseConfiguration : IApiConfiguration
    {
        public string ApiBaseUri
        {
            get
            {
                return "azure website";
            }
        }
    }
}
