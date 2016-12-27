using ConferenceTracker.Services.Interfaces;
using System.Threading.Tasks;
using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;

namespace ConferenceTracker.Services.Mock
{
    public class InfoService : IInfoService
    {
        public Task<GeneralResponse<ConferenceInfo>> GetInfo()
        {
            return Task.FromResult( new GeneralResponse<ConferenceInfo>()
            {
                IsSuccess = true,
                Value = new ConferenceInfo()
                {
                    Id = 0,
                    Info = @"Cras et ligula leo. Mauris ac viverra augue. Suspendisse a tempor felis, eget aliquet velit. Mauris dignissim mauris non risus venenatis, at facilisis dui aliquet. Morbi efficitur eros congue vulputate congue. Sed et tortor viverra, dapibus justo nec, aliquet nulla. Vestibulum bibendum ligula risus, ut eleifend diam cursus sit amet. Vivamus malesuada gravida est. Sed eu arcu ac odio sollicitudin laoreet non id sem. Quisque non quam at nunc facilisis mollis ac et justo. Aenean tellus erat, gravida in dapibus in, elementum a tellus. Ut tempor feugiat luctus. Donec quis leo sapien. Nullam urna mi, volutpat eu lacus sit amet, ornare semper felis.
                        Praesent ac lectus quis leo pellentesque lacinia ut at ante.Mauris nunc odio, vestibulum id porta ac, scelerisque a lectus.Vivamus rutrum maximus fringilla.Ut non turpis magna.Aenean viverra neque tortor, quis pulvinar metus pretium eget.Sed nibh arcu, eleifend ac mauris a, cursus dapibus leo.Maecenas eget mattis arcu.Quisque feugiat, sapien vel ultricies interdum, orci mi ornare mauris, ac dignissim ipsum nulla eu libero.Nulla sed leo urna.In fringilla leo est, eu aliquam leo cursus vitae."
                }
            });
        }
    }
}
