using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferenceTracker.Services.Interfaces
{
    public interface ISponsorsService
    {
        Task<GeneralResponse<IEnumerable<Sponsor>>> GetAllSponsors();
    }
}
