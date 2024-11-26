using System;
using System.Collections.Generic;

namespace MotorSports.EFDAL;

public partial class Participant
{
    public int ParticipantId { get; set; }

    public int UserId { get; set; }

    public string LicenseNumber { get; set; } = null!;

    public int? TeamId { get; set; }

    public virtual ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();

    public virtual Team? Team { get; set; }

    public virtual User User { get; set; } = null!;
}
