using ConferenceTracker.Data;
using System.Threading.Tasks;

namespace ConferenceTracker.Services.Interfaces
{
    public interface IInfoService
    {
        Task<ConferenceInfo> GetInfo();
    }
}
