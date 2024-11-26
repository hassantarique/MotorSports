using System;
using System.Collections.Generic;

namespace MotorSports.EFDAL;

public partial class Status
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
