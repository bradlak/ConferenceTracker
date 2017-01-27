using ConferenceTracker.Configurations;
using System.Net.Http;

namespace ConferenceTracker.Services
{
    public class BaseService
    {
        public BaseService(IApiConfiguration configuration)
        {
            this.configuration = configuration;

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        protected HttpClient client;

        protected IApiConfiguration configuration;
    }
}
