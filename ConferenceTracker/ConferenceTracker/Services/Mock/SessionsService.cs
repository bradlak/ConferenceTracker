using ConferenceTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConferenceTracker.Data;
using ConferenceTracker.Infrastructure;

namespace ConferenceTracker.Services.Mock
{
    public class SessionsService : ISessionsService
    {
        private ISpeakersService speakers;

        public SessionsService(ISpeakersService speakers)
        {
            this.speakers = speakers;
        }

        public Task<GeneralResponse<IEnumerable<Session>>> GetAllSessions()
        {
            var data = GetData();
            return Task.FromResult(new GeneralResponse<IEnumerable<Session>>()
            {
                IsSuccess = true,
                Value = data
            });
        }

        public IList<Session> GetData()
        {
            IList<Session> sessions = new List<Session>();
            var nextWeek = DateTime.Now.AddDays(7);

            sessions.Add(new Session()
            {
                Id = 0,
                Title = "MVVM pattern in WPF",
                Description = "Donec mollis eros dictum lectus consequat vestibulum. Nulla non libero aliquet, elementum lacus consequat, cursus massa. Etiam nec tortor vulputate, lobortis ipsum vel, egestas libero. Integer porttitor dapibus vestibulum. Ut non tincidunt lorem, imperdiet malesuada justo. Proin blandit lacus et risus dignissim, ultricies accumsan metus sollicitudin. ",
                Start = nextWeek,
                End = nextWeek.AddHours(2),
                Speakers = new List<Speaker>() { speakers.GetSpeakerById(0).Result.Value },
                IsFavourite = true
            });

            sessions.Add(new Session()
            {
                Id = 1,
                Title = "About SQL Injection",
                Description = "Pellentesque rhoncus purus orci, id volutpat arcu pulvinar id. Donec aliquet, tellus eget placerat vehicula, erat nisl rhoncus urna, eu molestie ante nibh in ipsum. Maecenas blandit elit ex, ac volutpat ante tincidunt eget. Integer lorem nisi, placerat nec accumsan ut, vulputate in dolor. ",
                Start = nextWeek.AddHours(3),
                End = nextWeek.AddHours(5),
                Speakers = new List<Speaker>() { speakers.GetSpeakerById(0).Result.Value, speakers.GetSpeakerById(1).Result.Value },
            });

            sessions.Add(new Session()
            {
                Id = 2,
                Title = "Usefull development tools",
                Description = "Curabitur feugiat diam eu volutpat vulputate. Mauris a mollis erat. In id placerat tellus. Duis sed fringilla sapien. Proin finibus venenatis lobortis. Pellentesque posuere elementum neque, ut rutrum mi vulputate a. ",
                Start = nextWeek.AddDays(1).AddHours(5),
                End = nextWeek.AddDays(1).AddHours(8),
                Speakers = new List<Speaker>() { speakers.GetSpeakerById(0).Result.Value },
            });

            sessions.Add(new Session()
            {
                Id = 3,
                Title = "ASP.NET MVC Introduction",
                Description = "Aliquam elit quam, posuere quis sem nec, lacinia fringilla ipsum. Morbi sed odio sagittis, dictum mi sed, dignissim dui. Donec pellentesque felis vitae tempus fringilla. Aenean ac commodo urna, vitae tincidunt nulla. ",
                Start = nextWeek.AddDays(2).AddHours(1),
                End = nextWeek.AddDays(2).AddHours(3),
                Speakers = new List<Speaker>() { speakers.GetSpeakerById(0).Result.Value, speakers.GetSpeakerById(1).Result.Value },
            });

            sessions.Add(new Session()
            {
                Id = 4,
                Title = "5 must have .NET libraries",
                Description = "Aenean at ullamcorper velit. In congue eget massa sed mollis. Vivamus consectetur fringilla sagittis. Etiam tincidunt, orci at sodales pulvinar, leo eros tristique eros, nec pellentesque justo leo nec est. Aliquam semper in dolor nec tristique.",
                Start = nextWeek.AddDays(3),
                End = nextWeek.AddDays(3).AddHours(3),
                Speakers = new List<Speaker>() { speakers.GetSpeakerById(0).Result.Value },
            });

            sessions.Add(new Session()
            {
                Id = 5,
                Title = "Unbelievable coffee",
                Description = "Vivamus vitae varius dolor. Integer ac rutrum nisl. Donec interdum ipsum ligula, in blandit ipsum hendrerit a. Morbi sit amet leo lobortis, aliquet nulla quis, semper neque.",
                Start = nextWeek.AddDays(3).AddHours(5),
                End = nextWeek.AddDays(3).AddHours(8),
                Speakers = new List<Speaker>() { speakers.GetSpeakerById(0).Result.Value, speakers.GetSpeakerById(1).Result.Value },
            });

            return sessions;
        }
    }
}
