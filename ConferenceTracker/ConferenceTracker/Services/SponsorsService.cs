using ConferenceTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceTracker.Data;
using ConferenceTracker.Configurations;
using ConferenceTracker.Infrastructure;
using Newtonsoft.Json;

namespace ConferenceTracker.Services
{
    public class SponsorsService : BaseService, ISponsorsService
    {
        public SponsorsService(IApiConfiguration configuration) 
            : base(configuration)
        {
        }

        public async Task<GeneralResponse<IEnumerable<Sponsor>>> GetAllSponsors()
        {
            string endpoint = "api/sponsors";

            GeneralResponse<IEnumerable<Sponsor>> result = new GeneralResponse<IEnumerable<Sponsor>>();

            var uri = new Uri(configuration.ApiBaseUri + endpoint);

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                result.IsSuccess = true;

                var content = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<List<Sponsor>>(content);
                result.Value = deserialized;
            }

            return result;
        }
    }
}
