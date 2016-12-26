using Newtonsoft.Json;
using System;

namespace ConferenceTracker.Data
{
    public class Event : BaseObject
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        [JsonIgnore]
        public string Dates
        {
            get
            {
                var startFormat = "dd MMMM yyyy, hh:mm";
                var endFormat = "hh:mm";
                return string.Format("{0} - {1}", Start.ToString(startFormat), End.ToString(endFormat));
            }
        }
    }
}
