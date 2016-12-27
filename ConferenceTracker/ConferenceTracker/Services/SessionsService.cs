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
    public class SessionsService : BaseService, ISessionsService
    {
        public SessionsService(IApiConfiguration configuration) 
            : base(configuration)
        {
        }

        public async Task<GeneralResponse<IEnumerable<Session>>> GetAllSessions()
        {
            string endpoint = "api/sessions";

            GeneralResponse<IEnumerable<Session>> result = new GeneralResponse<IEnumerable<Session>>();

            var uri = new Uri(configuration.ApiBaseUri + endpoint);

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                result.IsSuccess = true;

                var content = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<List<Session>>(content);
                result.Value = deserialized;
            }

            return result;
        }
    }
}
