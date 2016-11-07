using ConferenceTracker.Data;
using ConferenceTracker.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferenceTracker.Services.Mock
{
    public class SponsorsService : ISponsorsService
    {
        public Task<IEnumerable<Sponsor>> GetAllSponsors()
        {
            return Task.FromResult<IEnumerable<Sponsor>>(
                new List<Sponsor>() {
                    new Sponsor()
                    {
                       Id = 0,
                       ImageUrl = @"http://www.mcwade.com/DesignTalk/wp-content/uploads/2009/02/pepsilogowtext1.jpg",
                       Name = "Pepsi Company",
                       Level = SponsorLevel.Gold
                    },
                    new Sponsor()
                    {
                        Id = 1,
                        ImageUrl = @"http://www.parabolicarc.com/wp-content/uploads/2009/04/boeing_logo.jpg",
                        Name = "Boeing",
                        Level = SponsorLevel.Silver
                    },
                     new Sponsor()
                    {
                        Id = 2,
                        ImageUrl = @"http://thumbs.ebaystatic.com/images/m/mx1--oI5z9SLuCogVvbf-lg/s-l225.jpg",
                        Name = "Catepillar Inc.",
                        Level = SponsorLevel.Silver
                        
                    },
                      new Sponsor()
                    {
                         Id = 3,
                        ImageUrl = @"https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/Samsung_Logo.svg/800px-Samsung_Logo.svg.png",
                        Name = "Samsung Electronics.",
                        Level = SponsorLevel.Gold
                    },
                       new Sponsor()
                    {
                        Id = 4,
                        ImageUrl = @"http://seeklogo.com/images/M/mitsubishi-logo-1D8DD7203F-seeklogo.com.gif",
                        Name = "Mitsubishi Group",
                        Level = SponsorLevel.Bronze
                    }
                });
        }
    }
}
