using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSports.DomainObjects
{
    public class Sponsor
    {
        public int SponsorId { get; set; }

        public string SponsorName { get; set; } = null!;

        public string SponsorType { get; set; } = null!;

        public string ContactInfo { get; set; } = null!;
    }
}
