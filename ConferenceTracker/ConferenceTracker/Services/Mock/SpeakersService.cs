using ConferenceTracker.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;

namespace ConferenceTracker.Services.Mock
{
    public class SpeakersService : ISpeakersService
    {
        public Task<GeneralResponse<IEnumerable<Speaker>>> GetAllSpeakers()
        {
            return Task.FromResult(new GeneralResponse<IEnumerable<Speaker>>()
            {
                IsSuccess = true,
                Value = GetData()
            });
        }

        public Task<IEnumerable<Speaker>> GetContainingSpeakers(params int[] ids)
        {
            var data = GetData();
            var result = data.Where(z => ids.Contains(z.Id));
            return Task.FromResult<IEnumerable<Speaker>>(result);
        }

        public Task<Speaker> GetSpeakerById(int id)
        {
            var data = GetData();
            var result = data.Single(z => z.Id == id);
            return Task.FromResult<Speaker>(result);
        }

        IEnumerable<Speaker> GetData()
        {
            IList<Speaker> speakers = new List<Speaker>();
            speakers.Add(new Speaker()
            {
                Id = 0,
                FirstName = "Steve",
                LastName = "Jobs",
                Company = "Apple",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras sodales pellentesque elementum. Duis non fringilla mi, tempor suscipit odio. Donec arcu risus, sodales tincidunt justo id, pulvinar sodales justo. Mauris ac arcu at nisl fringilla gravida. Nam porttitor mi vitae felis tempor, laoreet pharetra odio malesuada. Pellentesque tempor ut enim in ultricies.",
                PhotoUrl = @"http://thenextweb.com/wp-content/blogs.dir/1/files/2009/11/steve-jobs1-239x300.jpg"
            });

            speakers.Add(new Speaker()
            {
                Id = 1,
                FirstName = "Bill",
                LastName = "Gates",
                Company = "Microsoft",
                Description = "Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed non pharetra ex. Suspendisse tempus, lorem et commodo mattis, leo dolor consequat orci, a condimentum nunc urna ut magna. Mauris in ante suscipit, pharetra libero eget, tristique tortor.",
                PhotoUrl = @"http://blogs.ubc.ca/sharmainekwok/files/2010/11/Bill-Gates1-300x232.jpg"
            });

            speakers.Add(new Speaker()
            {
                Id = 2,
                FirstName = "Satya",
                LastName = "Nadella",
                Company = "Microsoft",
                Description = "Vivamus id ullamcorper mi. Curabitur quis lorem lectus. Aliquam fermentum leo ornare condimentum imperdiet. Aliquam vel elit nec sapien tempus commodo. Integer in rutrum orci, in auctor metus. Donec in libero libero. Nunc eget purus lorem. ",
                PhotoUrl = @"http://cdn.ndtv.com/tech/images/gadgets/thumb/satya_nadella_reuters_small_858.jpg",
                FacebookUrl = " https://www.facebook.com/Nadella",
                TwitterUrl = " https://www.twitter.com/Nadella",
                GithubUrl = " https://www.github.com/CoderNadella"
            });

            speakers.Add(new Speaker()
            {
                Id = 3,
                FirstName = "Maria",
                LastName = "Skłodowska-Curie",
                Company = "Polon",
                Description = "Proin sagittis, dolor et fermentum ullamcorper, sem eros sagittis lorem, vel semper lorem orci sit amet turpis. Proin elementum nisl viverra nisi placerat, ac semper ipsum convallis. Pellentesque non lobortis felis. Integer viverra, ipsum at lacinia faucibus, mauris augue euismod enim, non pretium justo lorem quis dui.",
                PhotoUrl = @"http://www.kma4.republika.pl/3.jpg",
                FacebookUrl = " https://www.facebook.com/Polon"
            });

            speakers.Add(new Speaker()
            {
                Id = 4,
                FirstName = "Thomas",
                LastName = "Edison",
                Company = "TechThief",
                Description = "Sed condimentum dictum ex, eu maximus justo scelerisque quis. Ut purus tellus, congue non turpis id, sollicitudin posuere diam. Mauris faucibus laoreet varius. Vestibulum molestie, diam vitae pulvinar cursus, ligula dui elementum ipsum, eu venenatis erat elit ut diam. In nulla dolor, viverra nec tellus at, vestibulum lacinia ante.",
                PhotoUrl = @"http://media.hotbirthdays.com/upload/2015/05/17/thomas-edison.jpg",
                TwitterUrl = "https://www.twitter.com/Edison"
            });

            speakers.Add(new Speaker()
            {
                Id = 5,
                FirstName = "Isaac",
                LastName = "Newton",
                Company = "Gravity corp.",
                Description = "Donec ullamcorper lacinia faucibus. Duis a augue augue. Aenean ornare arcu risus, ac venenatis tortor tempor ac. Vivamus rutrum mauris quis lorem maximus, a venenatis massa varius. Donec tincidunt porta turpis vitae dapibus. Nam porta maximus gravida. Curabitur est nibh, tincidunt in porta sed, ullamcorper nec lorem.",
                PhotoUrl = @"http://www.thefamouspeople.com/profiles/images/isaac-newton-21.jpg",
                FacebookUrl = " https://www.facebook.com/Newton",
                GithubUrl = " https://www.github.com/OldSchoolCoder"
            });

            speakers.Add(new Speaker()
            {
                Id = 6,
                FirstName = "Albert",
                LastName = "Einstein",
                Company = "EmC2 Inc.",
                Description = "Fusce a enim eros. Maecenas nec convallis eros. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Integer id ipsum vel sapien bibendum volutpat. Nulla mattis sapien eu ante venenatis tincidunt.",
                PhotoUrl = @"http://www.spaceandmotion.com/Images/albert-einstein-theory-general-relativity.jpg"
            });

            speakers.Add(new Speaker()
            {
                Id = 7,
                FirstName = "Nikola",
                LastName = "Tesla",
                Company = "Energetouch",
                Description = "Aenean ut mi sit amet libero dapibus rutrum. Suspendisse dignissim orci sed semper gravida. Sed posuere neque enim, ac elementum risus maximus a. Morbi condimentum feugiat dolor et porta. Sed quis tellus at orci euismod viverra. Ut lacinia tellus enim, a sollicitudin mi venenatis nec. Mauris finibus risus massa, sit amet fermentum turpis scelerisque ut. ",
                PhotoUrl = @"http://www.panacomp.net/wp-content/uploads/2015/09/GORE335962_1.jpg"
            });

            return speakers;
        }
    }
}
