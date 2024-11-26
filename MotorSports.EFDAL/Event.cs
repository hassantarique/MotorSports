using System;
using System.Collections.Generic;

namespace MotorSports.EFDAL;

public partial class Event
{
    public int EventId { get; set; }

    public string EventName { get; set; } = null!;

    public int? VenueId { get; set; }

    public DateTime EventDate { get; set; }

    public int TotalLaps { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();

    public virtual ICollection<EventSponsor> EventSponsors { get; set; } = new List<EventSponsor>();

    public virtual Status? Status { get; set; }

    public virtual Venue? Venue { get; set; }
}
