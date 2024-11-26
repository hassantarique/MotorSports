using System;
using System.Collections.Generic;

namespace MotorSports.EFDAL;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PaswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
