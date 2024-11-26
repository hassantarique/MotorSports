using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSports.DomainObjects
{
    public class Participant
    {
        public int ParticipantId { get; set; }

        public int UserId { get; set; }

        public string LicenseNumber { get; set; } = null!;

        public int? TeamId { get; set; }


    }
}
