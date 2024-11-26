using System;
using System.Collections.Generic;

namespace MotorSports.EFDAL;

public partial class RaceSchedule
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateTime Date { get; set; }
}
