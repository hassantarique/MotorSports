using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSports.DomainObjects
{
    public class Event
    {

        public int EventId { get; set; }

        public string EventName { get; set; } = null!;

        public int? VenueId { get; set; }

        public string VenueName { get; set; } = null!;

        public DateTime EventDate { get; set; }

        public int TotalLaps { get; set; }

        public int? StatusId { get; set; }

        public string StatusName { get; set; } = null!;

        public List<Sponsor> EventSponsors { get; set; }


    }
}
