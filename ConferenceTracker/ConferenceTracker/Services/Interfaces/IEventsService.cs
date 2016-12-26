using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferenceTracker.Services.Interfaces
{
    public interface IEventsService
    {
        Task<GeneralResponse<IEnumerable<Event>>> GetAllEvents();
    }
}
