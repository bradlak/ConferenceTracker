using ConferenceTracker.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
