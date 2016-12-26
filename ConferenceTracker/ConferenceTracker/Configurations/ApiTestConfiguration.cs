namespace ConferenceTracker.Configurations
{
    public class ApiTestConfiguration : IApiConfiguration
    {
        public string ApiBaseUri
        {
            get
            {
                return "http://192.168.1.104:60000/";
            }
        }
    }
}
