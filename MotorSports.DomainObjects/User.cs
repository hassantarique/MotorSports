using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSports.DomainObjects
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public string PaswordHash { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }
    }
}
