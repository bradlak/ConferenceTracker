using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;
using System.Threading.Tasks;

namespace ConferenceTracker.Services.Interfaces
{
    public interface IInfoService
    {
        Task<GeneralResponse<ConferenceInfo>> GetInfo();
    }
}
