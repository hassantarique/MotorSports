using System;
using System.Collections.Generic;

namespace MotorSports.EFDAL;

public partial class Sponsor
{
    public int SponsorId { get; set; }

    public string SponsorName { get; set; } = null!;

    public string SponsorType { get; set; } = null!;

    public string ContactInfo { get; set; } = null!;

    public virtual ICollection<EventSponsor> EventSponsors { get; set; } = new List<EventSponsor>();
}
