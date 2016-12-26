using ConferenceTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceTracker.Data;
using System.Net.Http;
using Plugin.Connectivity;
using Newtonsoft.Json;
using Xamarin.Forms;
using ConferenceTracker.Configurations;
using ConferenceTracker.Infrastructure;

namespace ConferenceTracker.Services
{
    public class EventsService : IEventsService
    {
        IApiConfiguration configuration;

        HttpClient client;

        public EventsService(IApiConfiguration configuration)
        {
            this.configuration = configuration;

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<GeneralResponse<IEnumerable<Event>>> GetAllEvents()
        {
            string endpoint = "api/events";

            GeneralResponse<IEnumerable<Event>> result = new GeneralResponse<IEnumerable<Event>>();

            List<Event> events = new List<Event>();
            var uri = new Uri(configuration.ApiBaseUri + endpoint);

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                result.IsSuccess = true;

                var content = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<List<Event>>(content);
                result.Value = deserialized;
            }

            return result;
        }
    }
}
