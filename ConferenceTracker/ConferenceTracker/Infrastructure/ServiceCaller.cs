using ConferenceTracker.Messages;
using Plugin.Connectivity;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConferenceTracker.Infrastructure
{
    public class ServiceCaller : IServiceCaller
    {
        public async Task<GeneralResponse<TResult>> CallService<TResult>(
            Func<Task<GeneralResponse<TResult>>> serviceAction)
        {
            GeneralResponse<TResult> result = new GeneralResponse<TResult>();
            if (!IsConnected()) return result;

            try
            {
                var response = await serviceAction();
                if (response != null)
                {
                    result = response;
                }
            }
            catch(Exception ex)
            {
                MessagingCenter.Send(this, MessagesConsts.ApiCallingError, ex);                
            }

            return result;
        }

        private bool IsConnected()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                return true;
            }
            else
            {
                MessagingCenter.Send(this, MessagesConsts.NoInternet);
                return false;
            }
        }
    }
}
