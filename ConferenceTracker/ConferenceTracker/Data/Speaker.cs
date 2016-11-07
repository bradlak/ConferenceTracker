using System;

namespace ConferenceTracker.Data
{
    public class Speaker : BaseObject
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }

        public string Description { get; set; }

        public string PhotoUrl { get; set; }

    
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string GithubUrl { get; set; }


        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
    }
}
