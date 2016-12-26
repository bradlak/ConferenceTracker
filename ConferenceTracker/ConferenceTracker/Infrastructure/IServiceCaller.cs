using System;
using System.Threading.Tasks;

namespace ConferenceTracker.Infrastructure
{
    public interface IServiceCaller
    {
        Task<GeneralResponse<TResult>> CallService<TResult>(Func<Task<GeneralResponse<TResult>>> serviceAction);
    }
}
