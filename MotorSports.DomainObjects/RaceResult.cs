using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSports.DomainObjects
{
    public class RaceResult
    {
        public int RaceResultId { get; set; }

        public int EventParticipantId { get; set; }

        public TimeOnly LapTime { get; set; }

        public int LapNumber { get; set; }

        public int? Position { get; set; }
    }
}
