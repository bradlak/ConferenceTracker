using ConferenceTracker.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferenceTracker.Services.Interfaces
{
    public interface ISponsorsService
    {
        Task<IEnumerable<Sponsor>> GetAllSponsors();
    }
}
