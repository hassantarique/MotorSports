using System;
using System.Collections.Generic;

namespace MotorSports.EFDAL;

public partial class EventParticipant
{
    public int EventParticipantId { get; set; }

    public int EventId { get; set; }

    public int ParticipantId { get; set; }

    public int? TeamId { get; set; }

    public int RacePosition { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual Participant Participant { get; set; } = null!;

    public virtual ICollection<RaceResult> RaceResults { get; set; } = new List<RaceResult>();

    public virtual Team? Team { get; set; }
}
