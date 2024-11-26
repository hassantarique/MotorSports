using System;
using System.Collections.Generic;

namespace MotorSports.EFDAL;

public partial class Team
{
    public int TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public int TeamManagerId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();

    public virtual User TeamManager { get; set; } = null!;
}
