using System;
using System.Collections.Generic;

namespace MotorSports.EFDAL;

public partial class RaceStanding
{
    public int Id { get; set; }

    public string DriverName { get; set; } = null!;

    public int Position { get; set; }

    public int Points { get; set; }
}
