using System;
using System.Collections.Generic;

namespace ConferenceTracker.Data
{
    public class Session : BaseObject
    {
        public Session()
        {
            Speakers = new List<Speaker>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<Speaker> Speakers { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsFavourite { get; set; }

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
