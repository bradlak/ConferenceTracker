using ConferenceTracker.Services.Interfaces;
using System;
using System.Threading.Tasks;
using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;
using ConferenceTracker.Configurations;
using Newtonsoft.Json;

namespace ConferenceTracker.Services
{
    public class InfoService : BaseService, IInfoService
    {
        public InfoService(IApiConfiguration configuration) 
            : base(configuration)
        {
        }

        public async Task<GeneralResponse<ConferenceInfo>> GetInfo()
        {
            string endpoint = "api/info";

            GeneralResponse<ConferenceInfo> result = new GeneralResponse<ConferenceInfo>();

            var uri = new Uri(configuration.ApiBaseUri + endpoint);

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                result.IsSuccess = true;

                var content = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<ConferenceInfo>(content);
                result.Value = deserialized;
            }

            return result;
        }
    }
}
