using ConferenceTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;
using ConferenceTracker.Configurations;
using Newtonsoft.Json;

namespace ConferenceTracker.Services
{
    public class SpeakersService : BaseService, ISpeakersService
    {
        public SpeakersService(IApiConfiguration configuration)
            : base (configuration)
        {
        }

        public async Task<GeneralResponse<IEnumerable<Speaker>>> GetAllSpeakers()
        {
            string endpoint = "api/speakers";

            GeneralResponse<IEnumerable<Speaker>> result = new GeneralResponse<IEnumerable<Speaker>>();

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

        public async Task<GeneralResponse<Speaker>> GetSpeakerById(int id)
        {
            string endpoint = "api/speakers/" + id;

            GeneralResponse<Speaker> result = new GeneralResponse<Speaker>();

            var uri = new Uri(configuration.ApiBaseUri + endpoint);

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                result.IsSuccess = true;

                var content = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<Speaker>(content);
                result.Value = deserialized;
            }

            return result;
        }
    }
}
