using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSports.DomainObjects
{
    public class RaceStanding
    {
        public int Id { get; set; }
        public string DriverName { get; set; }
        public int Position { get; set; }
        public int Points { get; set; }
    }
}
