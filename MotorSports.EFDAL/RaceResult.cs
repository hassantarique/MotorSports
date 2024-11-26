using System;
using System.Collections.Generic;

namespace MotorSports.EFDAL;

public partial class RaceResult
{
    public int RaceResultId { get; set; }

    public int EventParticipantId { get; set; }

    public TimeOnly LapTime { get; set; }

    public int LapNumber { get; set; }

    public int? Position { get; set; }

    public TimeOnly? FinishTime { get; set; }

    public virtual EventParticipant EventParticipant { get; set; } = null!;
}
