using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferenceTracker.Services.Interfaces
{
    public interface ISpeakersService
    {
        Task<GeneralResponse<IEnumerable<Speaker>>> GetAllSpeakers();

        Task<GeneralResponse<Speaker>> GetSpeakerById(int id);
    }
}
