using ConferenceTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConferenceTracker.Data;

namespace ConferenceTracker.Services.Mock
{
    public class EventsService : IEventsService
    {
        public Task<IEnumerable<Event>> GetAllEvents()
        {
            var data = GetData();
            return Task.FromResult(data);
        }

        private IEnumerable<Event> GetData()
        {
            IList<Event> events = new List<Event>();

            var aBitLater = DateTime.Now.AddDays(3);

            events.Add(new Event()
            {
                Id = 0,
                Title = "Counter-Strike Challange",
                Description = "Join team and win amazing prizes in competition.",
                Start = aBitLater.AddHours(2),
                End = aBitLater.AddHours(7)
            });

            events.Add(new Event()
            {
                Id = 1,
                Title = "League of legends. Ashe sniper",
                Description = "Check out your aiming skills with Ashe's special arrow.",
                Start = aBitLater.AddDays(1).AddHours(2),
                End = aBitLater.AddDays(1).AddHours(7)
            });

            events.Add(new Event()
            {
                Id = 2,
                Title = "Pizza party",
                Description = "Eat pizza as much you can. It's free!",
                Start = aBitLater.AddDays(2).AddHours(1),
                End = aBitLater.AddDays(2).AddHours(3)
            });


            return events;
        }
    }
}
