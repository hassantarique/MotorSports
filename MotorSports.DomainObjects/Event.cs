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

        public DateTime EventDate { get; set; }

        public int TotalLaps { get; set; }

        public int? StatusId { get; set; }

    }
}
