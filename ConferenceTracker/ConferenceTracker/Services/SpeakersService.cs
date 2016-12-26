using ConferenceTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;
using ConferenceTracker.Configurations;
using System.Net.Http;
using Newtonsoft.Json;

namespace ConferenceTracker.Services
{
    public class SpeakersService : ISpeakersService
    {
        IApiConfiguration configuration;

        HttpClient client;

        public SpeakersService(IApiConfiguration configuration)
        {
            this.configuration = configuration;

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<GeneralResponse<IEnumerable<Speaker>>> GetAllSpeakers()
        {
            string endpoint = "api/speakers";

            GeneralResponse<IEnumerable<Speaker>> result = new GeneralResponse<IEnumerable<Speaker>>();

            List<Event> events = new List<Event>();
            var uri = new Uri(configuration.ApiBaseUri + endpoint);
            
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                result.IsSuccess = true;

                var content = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<List<Speaker>>(content);
                result.Value = deserialized;
            }

            return result;
        }

        public Task<IEnumerable<Speaker>> GetContainingSpeakers(params int[] ids)
        {
            throw new NotImplementedException();
        }

        public Task<Speaker> GetSpeakerById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
