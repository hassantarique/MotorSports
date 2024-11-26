using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSports.DomainObjects
{
    public class Team
    {

        public int TeamId { get; set; }

        public string TeamName { get; set; } = null!;

        public int TeamManagerId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
