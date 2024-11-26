﻿using System;
using System.Collections.Generic;

namespace MotorSports.EFDAL;

public partial class EventSponsor
{
    public int EventSponsorId { get; set; }

    public int EventId { get; set; }

    public int SponsorId { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual Sponsor Sponsor { get; set; } = null!;
}
