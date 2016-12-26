using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferenceTracker.Services.Interfaces
{
    public interface ISpeakersService
    {
        Task<GeneralResponse<IEnumerable<Speaker>>> GetAllSpeakers();

        Task<Speaker> GetSpeakerById(int id);

        Task<IEnumerable<Speaker>> GetContainingSpeakers(params int[] ids);
    }
}
