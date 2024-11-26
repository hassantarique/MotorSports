using Microsoft.EntityFrameworkCore;
using MotorSports.EFDAL;

internal class Program
{


    static void Main(string[] args)
    {
        int userSelection = 0;

        do
        {
            showUserRoles();

            Console.WriteLine("Please enter your role (8 to exit):");

            // Handle input validation directly using TryParse
            if (!int.TryParse(Console.ReadLine(), out userSelection) || userSelection < 1 || userSelection > 8)
            {
                if (userSelection != 8)
                {
                    Console.WriteLine("Invalid input! Please enter a valid number between 1 and 8.");
                }
                continue;
            }

            // If user selects 8, exit with a message
            if (userSelection == 8)
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                break;
            }

            Console.WriteLine($"Showing Options For Role {userSelection}...");
            Console.WriteLine("");

            // Process menu based on the role selected
            switch (userSelection)
            {
                case 1:
                    eventOrganizerMenu();
                    break;
                case 2:
                    participantMenu();
                    break;
                case 3:
                    teamManagerMenu();
                    break;
                case 4:
                    spectatorMenu();
                    break;
                case 5:
                    raceOfficialMenu();
                    break;
                case 6:
                    sponsorMenu();
                    break;
                case 7:
                    adminMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Selection, Try Again.");
                    break;
            }

        } while (true); // Continue indefinitely until user selects 8 to exit
    }


    static void showUserRoles()
    {
        Console.WriteLine("");
        Console.WriteLine("===MotorSportsManagement===");
        Console.WriteLine("Select Role: ");
        Console.WriteLine("1. Event Organizer");
        Console.WriteLine("2. Participant");
        Console.WriteLine("3. Team Manager");
        Console.WriteLine("4. Spectator");
        Console.WriteLine("5. Race Official");
        Console.WriteLine("6. Sponsor");
        Console.WriteLine("7. System Admin");
        Console.WriteLine("8. Exit App");
        Console.WriteLine("");
    }

    static void eventOrganizerMenu()
    {
        int choice;
        do
        {
            ShowEventOrganizerMenu();

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }


            switch (choice)
            {
                case 1:
                    Console.WriteLine("Creating Event...");
                    CreateEvent();
                    break;
                case 2:
                    Console.WriteLine("Managing Event...");
                    managingEvent();
                    break;
                case 3:
                    Console.WriteLine("Viewing Events...");
                    ViewEvents();
                    break;
                case 4:
                    Console.WriteLine("Returning to Main Menu...");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    break;
            }
        } while (choice != 4);
    }

    static void ShowEventOrganizerMenu()
    {
        Console.WriteLine("");
        Console.WriteLine("=== Event Organizer Menu ===");
        Console.WriteLine("1. Create Event");
        Console.WriteLine("2. Manage Event");
        Console.WriteLine("3. View Events");
        Console.WriteLine("4. Return to Main Menu");
        Console.WriteLine("");
    }

    static void managingEvent()
    {
        int choice;
        do
        {
            ShowManagingEventOptions();

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Assigning Sponsors: ");
                    AssignSponsorToEvent();
                    break;
                case 2:
                    Console.WriteLine("Assigning Status: ");
                    AssignStatusToEvent();
                    break;
                case 3:
                    Console.WriteLine("Assigning Teams: ");
                    AssignTeamToEventOption();
                    break;
                case 4:
                    Console.WriteLine("Assigning Venue: ");
                    AssignVenueToEvent();
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid Selection, try again.");
                    break;

            }
        } while (choice != 5);
    }

    static void ShowManagingEventOptions()
    {
        Console.WriteLine("");
        Console.WriteLine("1. Assign Sponsor to Event...");
        Console.WriteLine("2. Assign Status to Event...");
        Console.WriteLine("3. Assign Team to Event...");
        Console.WriteLine("4. Assign Venue to Event...");
        Console.WriteLine("5. Return to Previous Menu.");
        Console.WriteLine("");
    }

    //============================================================================================================================================

    static void CreateEvent()
    {
        using var context = new MotorSports_2Context();

        Console.Write("Enter Event Name: ");
        string eventName = Console.ReadLine();

        DateTime eventDate;
        while (true)
        {
            Console.Write("Enter Event Date (yyyy-MM-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out eventDate)) break;
            Console.WriteLine("Invalid date format. Please try again.");
        }

        Console.Write("Enter Event Status: ");
        string eventStatus = Console.ReadLine();

        int sponsorId;
        while (true)
        {
            Console.Write("Enter Sponsor ID: ");
            if (int.TryParse(Console.ReadLine(), out sponsorId)) break;
            Console.WriteLine("Invalid input. Please enter a valid Sponsor ID.");
        }

        int venueId;
        while (true)
        {
            Console.Write("Enter Venue ID: ");
            if (int.TryParse(Console.ReadLine(), out venueId)) break;
            Console.WriteLine("Invalid input. Please enter a valid Venue ID.");
        }

        var newEvent = new Event
        {
            EventName = eventName,
            EventDate = eventDate,
            StatusId = Convert.ToInt32(eventStatus),
            VenueId = venueId
        };

        context.Events.Add(newEvent);
        context.SaveChanges();

        Console.WriteLine("Event created successfully!");
    }

    static void AssignSponsorToEvent()
    {
        using var context = new MotorSports_2Context();

        int eventId;
        while (true)
        {
            Console.Write("Enter Event ID: ");
            if (int.TryParse(Console.ReadLine(), out eventId)) break;
            Console.WriteLine("Invalid input. Please enter a valid Event ID.");
        }

        Console.Write("Enter Sponsor Name: ");
        string sponsorName = Console.ReadLine();

        var existingEvent = context.Events.FirstOrDefault(e => e.EventId == eventId);
        if (existingEvent == null)
        {
            Console.WriteLine("Event not found.");
            return;
        }
        // Check if the Sponsor exists
        var existingSponsor = context.Sponsors.FirstOrDefault(s => s.SponsorName == sponsorName);
        if (existingSponsor == null)
        {
            Console.WriteLine("Sponsor not found. Please ensure the Sponsor exists.");
            return;
        }

        var eventSponsor = new EventSponsor
        {
            EventId = eventId,
            SponsorId = existingSponsor.SponsorId
        };

        context.EventSponsors.Add(eventSponsor);
        context.SaveChanges();

        Console.WriteLine("Sponsor added to event successfully!");
    }

    static void AssignStatusToEvent()
    {
        Console.Write("Enter Event ID to assign status: ");
        if (!int.TryParse(Console.ReadLine(), out int eventId))
        {
            Console.WriteLine("Invalid input. Please enter a valid Event ID.");
            return;
        }

        var statuses = GetAllStatuses();

        if (statuses == null || statuses.Count == 0)
        {
            Console.WriteLine("No statuses available.");
            return;
        }

        Console.WriteLine("Available Statuses:");
        for (int i = 0; i < statuses.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {statuses[i].StatusName}");
        }

        Console.Write("Select a status by number: ");
        if (!int.TryParse(Console.ReadLine(), out int statusChoice) || statusChoice < 1 || statusChoice > statuses.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        int selectedStatusId = statuses[statusChoice - 1].StatusId;

        if (UpdateEventStatus(eventId, selectedStatusId))
        {
            Console.WriteLine("Status successfully assigned to the event.");
        }
        else
        {
            Console.WriteLine("Failed to assign status to the event.");
        }
    }

    static List<Status> GetAllStatuses()
    {
        using (var context = new MotorSports_2Context())
        {
            return context.Statuses.ToList();
        }
    }

    static bool UpdateEventStatus(int eventId, int statusId)
    {
        using (var context = new MotorSports_2Context())
        {
            var eventToUpdate = context.Events.FirstOrDefault(e => e.EventId == eventId);

            if (eventToUpdate == null)
            {
                Console.WriteLine("Event not found.");
                return false;
            }

            eventToUpdate.StatusId = statusId;
            context.SaveChanges();
            return true;
        }
    }

    static void AssignTeamToEvent(int eventId, int teamId)
    {
        using (var context = new MotorSports_2Context())
        {
            var teamParticipants = context.Participants
                .Where(p => p.TeamId == teamId)
                .ToList();

            if (!teamParticipants.Any())
            {
                Console.WriteLine("No participants found for this team.");
                return;
            }

            foreach (var participant in teamParticipants)
            {
                var eventParticipant = new EventParticipant
                {
                    EventId = eventId,
                    ParticipantId = participant.ParticipantId
                };
                context.EventParticipants.Add(eventParticipant);
            }

            context.SaveChanges();
            Console.WriteLine("Team assigned and participants added to the event.");
        }
    }

    static void AssignTeamToEventOption()
    {
        int eventId;
        int teamId;

        Console.WriteLine("Enter Event ID to assign team to:");
        if (!int.TryParse(Console.ReadLine(), out eventId))
        {
            Console.WriteLine("Invalid input for Event ID.");
            return;
        }

        Console.WriteLine("Enter Team ID to assign:");
        if (!int.TryParse(Console.ReadLine(), out teamId))
        {
            Console.WriteLine("Invalid input for Team ID.");
            return;
        }

        AssignTeamToEvent(eventId, teamId);
    }

    static void AssignVenueToEvent()
    {
        using var context = new MotorSports_2Context();

        int eventId;
        while (true)
        {
            Console.Write("Enter Event ID: ");
            if (int.TryParse(Console.ReadLine(), out eventId)) break;
            Console.WriteLine("Invalid input. Please enter a valid Event ID.");
        }

        var existingEvent = context.Events.FirstOrDefault(e => e.EventId == eventId);
        if (existingEvent == null)
        {
            Console.WriteLine("Event not found.");
            return;
        }

        Console.Write("Enter Venue ID: ");
        int venueId;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out venueId)) break;
            Console.WriteLine("Invalid input. Please enter a valid Venue ID.");
        }

        var existingVenue = context.Venues.FirstOrDefault(v => v.VenueId == venueId);
        if (existingVenue == null)
        {
            Console.WriteLine("Venue not found. Please ensure the Venue exists.");
            return;
        }

        existingEvent.VenueId = venueId;
        context.SaveChanges();

        Console.WriteLine("Venue assigned to the event successfully!");
    }

    static void ViewEvents()
    {
        using (var context = new MotorSports_2Context())
        {
            var events = context.Events.ToList();

            if (events.Any())
            {
                Console.WriteLine("\n=== List of Events ===");
                foreach (var ev in events)
                {
                    Console.WriteLine($"ID: {ev.EventId} | Name: {ev.EventName} | Date: {ev.EventDate} | VenueId: {ev.VenueId}");
                }
            }
            else
            {
                Console.WriteLine("No events found.");
            }
        }
    }

    //===========================================================================================================================================

    static void participantMenu()
    {
        int choice;
        do
        {
            ShowParticipantMenuOptions();

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Viewing Upcoming Races...");
                    ViewUpcomingRaces();
                    break;
                case 2:
                    Console.WriteLine("Registering for Race...");
                    RegisterForRace();
                    break;
                case 3:
                    Console.WriteLine("Viewing Results...");
                    ViewResults();
                    break;
                case 4:
                    Console.WriteLine("Returning to Main Menu...");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    break;
            }
        } while (choice != 4);
    }

    static void ShowParticipantMenuOptions()
    {
        Console.WriteLine("");
        Console.WriteLine("=== Participant Menu ===");
        Console.WriteLine("1. View Upcoming Races");
        Console.WriteLine("2. Register for Race");
        Console.WriteLine("3. View Results");
        Console.WriteLine("4. Return to Main Menu");
        Console.WriteLine("");
    }

    static void ViewUpcomingRaces()
    {
        using (var context = new MotorSports_2Context())
        {
            var upcomingRaces = context.Events
                .Where(e => e.EventDate > DateTime.Now)
                .Select(e => new
                {
                    e.EventId,
                    e.EventName,
                    e.EventDate,
                    Venue = e.Venue.VenueName
                })
                .ToList();

            Console.WriteLine("Upcoming Races:");
            foreach (var race in upcomingRaces)
            {
                Console.WriteLine($"Event ID: {race.EventId}, Name: {race.EventName}, Date: {race.EventDate}, Venue: {race.Venue}");
            }
        }
    }

    static void RegisterForRace()
    {
        Console.Write("Enter Event ID to register for: ");
        if (!int.TryParse(Console.ReadLine(), out int eventId))
        {
            Console.WriteLine("Invalid Event ID.");
            return;
        }

        Console.Write("Enter Participant ID: ");
        if (!int.TryParse(Console.ReadLine(), out int participantId))
        {
            Console.WriteLine("Invalid Participant ID.");
            return;
        }

        using (var context = new MotorSports_2Context())
        {
            var eventExists = context.Events.Any(e => e.EventId == eventId);
            var participantExists = context.Participants.Any(p => p.ParticipantId == participantId);

            if (!eventExists || !participantExists)
            {
                Console.WriteLine("Invalid Event ID or Participant ID.");
                return;
            }

            var alreadyRegistered = context.EventParticipants
                .Any(ep => ep.EventId == eventId && ep.ParticipantId == participantId);

            if (alreadyRegistered)
            {
                Console.WriteLine("Participant is already registered for this event.");
            }
            else
            {
                var newRegistration = new EventParticipant
                {
                    EventId = eventId,
                    ParticipantId = participantId,
                    //EventParticipantId = 0
                };

                context.EventParticipants.Add(newRegistration);
                context.SaveChanges();                          //error while saving changes to database; identity insert is off for event participants*
                Console.WriteLine("Registration successful.");
            }
        }
    }

    static void ViewResults()
    {
        Console.Write("Enter Event ID to view results: ");
        if (!int.TryParse(Console.ReadLine(), out int eventId))
        {
            Console.WriteLine("Invalid Event ID.");
            return;
        }

        using (var context = new MotorSports_2Context())
        {
            var results = context.RaceResults
                .Where(r => r.EventParticipant.EventId == eventId)
                .Select(r => new
                {
                    r.EventParticipant.Participant.ParticipantId,
                    ParticipantName = r.EventParticipant.Participant.User.FirstName + " " + r.EventParticipant.Participant.User.LastName,
                    r.LapTime,
                    r.LapNumber,
                    r.Position,
                    r.FinishTime
                })
                .OrderBy(r => r.Position)
                .ToList();

            if (!results.Any())
            {
                Console.WriteLine("No results found for this event.");
                return;
            }

            Console.WriteLine("Race Results:");
            foreach (var result in results)
            {
                Console.WriteLine($"Participant ID: {result.ParticipantId}, Name: {result.ParticipantName}, Position: {result.Position}, Finish Time: {result.FinishTime}, Lap Number: {result.LapNumber}, Lap Time: {result.LapTime}");
            }
        }
    }

    //============================================================================================================================================

    static void teamManagerMenu()
    {
        int choice;
        do
        {
            ShowTeamManagerMenu();

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Managing Team...");
                    ManageTeam();
                    break;
                case 2:
                    Console.WriteLine("Viewing Team Performance...");
                    ViewTeamPerformance();
                    break;
                case 3:
                    Console.WriteLine("Returning to Main Menu...");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    break;
            }
        } while (choice != 3);
    }

    static void ShowTeamManagerMenu()
    {
        Console.WriteLine("");
        Console.WriteLine("=== Team Manager Menu ===");
        Console.WriteLine("1. Manage Team");
        Console.WriteLine("2. View Team Performance");
        Console.WriteLine("3. Return to Main Menu");
        Console.WriteLine("");
    }

    static void ManageTeam()
    {
        int choice;
        do
        {
            ShowManageTeamMenu();

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Adding Player...");
                    AddPlayer();
                    break;
                case 2:
                    Console.WriteLine("Removing Player...");
                    RemovePlayer();
                    break;
                case 3:
                    Console.WriteLine("Viewing Players...");
                    ViewPlayers();
                    break;
                case 4:
                    Console.WriteLine("Returning to Team Manager Menu...");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    break;
            }
        } while (choice != 4);
    }

    static void ShowManageTeamMenu()
    {
        Console.WriteLine("");
        Console.WriteLine("=== Manage Team ===");
        Console.WriteLine("1. Add Player");
        Console.WriteLine("2. Remove Player");
        Console.WriteLine("3. View Players");
        Console.WriteLine("4. Return to Team Manager Menu");
        Console.WriteLine("");
    }

    static void AddPlayer()
    {
        Console.Write("Enter Participant ID to add to a team: ");
        if (!int.TryParse(Console.ReadLine(), out int participantId))
        {
            Console.WriteLine("Invalid Participant ID.");
            return;
        }

        Console.Write("Enter Team ID to assign the player to: ");
        if (!int.TryParse(Console.ReadLine(), out int teamId))
        {
            Console.WriteLine("Invalid Team ID.");
            return;
        }

        using (var context = new MotorSports_2Context())
        {
            var participant = context.Participants.SingleOrDefault(p => p.ParticipantId == participantId);
            if (participant == null)
            {
                Console.WriteLine("Participant not found.");
                return;
            }

            var teamExists = context.Teams.Any(t => t.TeamId == teamId);
            if (!teamExists)
            {
                Console.WriteLine("Team not found.");
                return;
            }

            participant.TeamId = teamId;
            context.SaveChanges();

            Console.WriteLine("Player has been successfully added to the team.");
        }
    }

    static void RemovePlayer()
    {
        Console.Write("Enter Participant ID to remove from the team: ");
        if (!int.TryParse(Console.ReadLine(), out int participantId))
        {
            Console.WriteLine("Invalid Participant ID.");
            return;
        }

        using (var context = new MotorSports_2Context())
        {
            var participant = context.Participants.SingleOrDefault(p => p.ParticipantId == participantId);
            if (participant == null || participant.TeamId == null)
            {
                Console.WriteLine("Participant not found or not assigned to any team.");
                return;
            }

            // Remove the player from the team
            participant.TeamId = null;
            context.SaveChanges();

            Console.WriteLine("Player has been successfully removed from the team.");
        }
    }

    static void ViewPlayers()
    {
        using (var context = new MotorSports_2Context())
        {
            var players = context.Participants
                .Select(p => new
                {
                    p.ParticipantId,
                    p.UserId,
                    TeamName = p.TeamId != null ? context.Teams
                        .Where(t => t.TeamId == p.TeamId)
                        .Select(t => t.TeamName)
                        .FirstOrDefault() : "No Team"
                })
                .ToList();

            Console.WriteLine("\n=== List of All Players ===");
            foreach (var player in players)
            {
                Console.WriteLine($"ID: {player.ParticipantId}, UserId: {player.UserId}, Team: {player.TeamName}");
            }
        }
    }

    static void ViewTeamPerformance()
    {
        Console.Write("Enter Team ID to view performance: ");
        if (!int.TryParse(Console.ReadLine(), out int teamId))
        {
            Console.WriteLine("Invalid Team ID.");
            return;
        }

        using (var context = new MotorSports_2Context())
        {
            var participants = context.Participants
                .Where(p => p.TeamId == teamId)
                .ToList();

            if (participants.Count == 0)
            {
                Console.WriteLine("No participants found for this team.");
                return;
            }

            Console.WriteLine("\n=== Team Performance Overview ===");

            foreach (var participant in participants)
            {
                var participantName = context.Users
                    .Where(u => u.UserId == participant.UserId)
                    .Select(u => u.FirstName + " " + u.LastName)
                    .FirstOrDefault();

                Console.WriteLine($"\nParticipant: {participantName} (ID: {participant.ParticipantId})");
                Console.WriteLine($"Team ID: {participant.TeamId}");

                var raceResults = context.RaceResults
                    .Where(rr => rr.EventParticipant.ParticipantId == participant.ParticipantId)
                    .ToList();

                if (raceResults.Count == 0)
                {
                    Console.WriteLine("  No race results available for this participant.");
                }
                else
                {
                    foreach (var result in raceResults)
                    {
                        Console.WriteLine($"  Race Result: Position {result.Position ?? -1}, Lap {result.LapNumber}, " +
                            $"Lap Time {result.LapTime}, Finish Time {result.FinishTime ?? TimeOnly.MinValue}");
                    }
                }
            }
        }
    }

    //============================================================================================================================================

    static void spectatorMenu()
    {
        int choice;
        do
        {
            ShowSpectatorMenuOptions();

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Viewing Race Schedule...");
                    ViewRaceSchedule();
                    break;
                case 2:
                    Console.WriteLine("Viewing Race Standings...");
                    ViewRaceStandings();
                    break;
                case 3:
                    Console.WriteLine("Returning to Main Menu...");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    break;
            }
        } while (choice != 3);
    }

    static void ShowSpectatorMenuOptions()
    {
        Console.WriteLine("");
        Console.WriteLine("=== Spectator Menu ===");
        Console.WriteLine("1. View Race Schedule");
        Console.WriteLine("2. View Race Standings");
        Console.WriteLine("3. Return to Main Menu");
        Console.WriteLine("");
    }

    static void ViewRaceSchedule()
    {
        try
        {
            using (var context = new MotorSports_2Context())
            {
                var schedule = context.RaceSchedules.ToList();

                if (schedule.Any())
                {
                    Console.WriteLine("Race Schedule:");
                    foreach (var race in schedule)
                    {
                        Console.WriteLine($"{race.Date}: {race.Name} at {race.Location}");
                    }
                }
                else
                {
                    Console.WriteLine("No races scheduled.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving race schedule. " + ex.Message);
        }
    }

    static void ViewRaceStandings()
    {
        try
        {
            using (var context = new MotorSports_2Context())
            {
                var standings = context.RaceStandings.ToList();

                if (standings.Any())
                {
                    Console.WriteLine("Race Standings:");
                    foreach (var standing in standings)
                    {
                        Console.WriteLine($"{standing.Position}: {standing.DriverName} - {standing.Points} points");
                    }
                }
                else
                {
                    Console.WriteLine("No standings available.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving race standings. " + ex.Message);
        }
    }

    //============================================================================================================================================

    static void raceOfficialMenu()
    {
        int choice;
        do
        {
            ShowRaceOfficialMenuOptions();

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Showing Results...");
                    ShowResults();
                    break;
                case 2:
                    Console.WriteLine("Assigning Positions...");
                    AssignPositions();
                    break;
                case 3:
                    Console.WriteLine("Returning To Main Menu...");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    break;
            }
        } while (choice != 3);
    }

    static void ShowRaceOfficialMenuOptions()
    {
        Console.WriteLine("");
        Console.WriteLine("=== Race Official Menu ===");
        Console.WriteLine("1. Show Results");
        Console.WriteLine("2. Assign Positions");
        Console.WriteLine("3. Return to Main Menu");
        Console.WriteLine("");
    }

    static void ShowResults()
    {
        using (var context = new MotorSports_2Context())
        {
            var raceResults = context.RaceResults.ToList();

            Console.WriteLine("\n=== Race Results ===");
            foreach (var result in raceResults)
            {
                var participant = context.Participants.FirstOrDefault(p => p.ParticipantId == result.EventParticipant.ParticipantId);
                var eventId = result.EventParticipant.EventId;
                Console.WriteLine($"Event ID: {eventId}, Participant ID: {result.EventParticipant.ParticipantId}, " +
                    $"Lap Time: {result.LapTime}, Position: {result.Position ?? -1}, Finish Time: {result.FinishTime?.ToString() ?? "N/A"}");
            }
        }
    }

    static void AssignPositions()
    {
        Console.Write("Enter Event ID to assign positions for: ");
        if (!int.TryParse(Console.ReadLine(), out int eventId))
        {
            Console.WriteLine("Invalid Event ID.");
            return;
        }

        using (var context = new MotorSports_2Context())
        {
            var raceResults = context.RaceResults.Where(rr => rr.EventParticipant.EventId == eventId).ToList();

            if (raceResults.Count == 0)
            {
                Console.WriteLine("No race results found for this event.");
                return;
            }

            Console.WriteLine("\n=== Assign Positions ===");
            foreach (var result in raceResults)
            {
                Console.WriteLine($"Participant ID: {result.EventParticipant.ParticipantId}, " +
                    $"Current Position: {result.Position ?? -1}, Lap Time: {result.LapTime}");

                Console.Write($"Enter position for Participant ID {result.EventParticipant.ParticipantId}: ");
                if (int.TryParse(Console.ReadLine(), out int position))
                {
                    result.Position = position;
                    context.SaveChanges();
                    Console.WriteLine($"Position assigned to Participant {result.EventParticipant.ParticipantId}: {position}");
                }
                else
                {
                    Console.WriteLine("Invalid position. Skipping this participant.");
                }
            }
        }
    }

    //============================================================================================================================================

    static void sponsorMenu()
    {
        int choice;
        do
        {
            ShowSponsorMenuOptions();

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Viewing Sponsored Teams...");
                    ViewMySponsoredEvents();
                    break;
                case 2:
                    Console.WriteLine("Removing Sponsorship..");
                    RemoveSponsorship();
                    break;
                case 3:
                    Console.WriteLine("Returning to Main Menu...");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    break;
            }
        } while (choice != 3);
    }

    static void ShowSponsorMenuOptions()
    {
        Console.WriteLine("");
        Console.WriteLine("=== Sponsor Menu ===");
        Console.WriteLine("1. View My Sponsored Teams");
        Console.WriteLine("2. Remove Sponshorship From a Team");
        Console.WriteLine("3. Return to Main Menu");
        Console.WriteLine("");
    }

    static void ViewMySponsoredEvents()
    {
        Console.Write("Enter Sponsor ID to view sponsored events: ");
        if (!int.TryParse(Console.ReadLine(), out int sponsorId))
        {
            Console.WriteLine("Invalid Sponsor ID.");
            return;
        }

        using (var context = new MotorSports_2Context())
        {
            var sponsoredEvents = context.EventSponsors
                .Where(es => es.SponsorId == sponsorId)
                .Select(es => new
                {
                    es.EventId,
                    EventName = context.Events
                        .Where(e => e.EventId == es.EventId)
                        .Select(e => e.EventName)
                        .FirstOrDefault()
                })
                .ToList();

            if (sponsoredEvents.Count == 0)
            {
                Console.WriteLine("No events found for this sponsor.");
                return;
            }

            Console.WriteLine("\n=== Sponsored Events ===");
            foreach (var e in sponsoredEvents)
            {
                Console.WriteLine($"Event ID: {e.EventId}, Event Name: {e.EventName}");
            }
        }
    }

    static void RemoveSponsorship()
    {
        Console.Write("Enter Sponsor ID: ");
        if (!int.TryParse(Console.ReadLine(), out int sponsorId))
        {
            Console.WriteLine("Invalid Sponsor ID.");
            return;
        }

        Console.Write("Enter Event ID to remove sponsorship from: ");
        if (!int.TryParse(Console.ReadLine(), out int eventId))
        {
            Console.WriteLine("Invalid Event ID.");
            return;
        }

        using (var context = new MotorSports_2Context())
        {
            var sponsorship = context.EventSponsors
                .Where(es => es.SponsorId == sponsorId && es.EventId == eventId)
                .FirstOrDefault();

            if (sponsorship == null)
            {
                Console.WriteLine("Sponsorship not found between this sponsor and event.");
                return;
            }

            context.EventSponsors.Remove(sponsorship);
            context.SaveChanges();

            Console.WriteLine("Sponsorship has been successfully removed.");
        }
    }

    //============================================================================================================================================

    static void adminMenu()
    {
        int choice;
        do
        {
            ShowAdminMenuOptions();

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Managing Users & Roles...");
                    ManageUsersAndRoles();
                    break;
                case 2:
                    Console.WriteLine("Managing Event Statuses...");
                    ManageEventStatuses();
                    break;
                case 3:
                    Console.WriteLine("Returning to Main Menu...");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    break;
            }
        } while (choice != 3);
    }

    static void ShowAdminMenuOptions()
    {
        Console.WriteLine("");
        Console.WriteLine("=== System Admin Menu ===");
        Console.WriteLine("1. Manage Users & Roles");
        Console.WriteLine("2. Manage Event Statuses");
        Console.WriteLine("3. Return To Main Menu");
        Console.WriteLine("");
    }

    static void ManageUsersAndRoles()
    {
        Console.WriteLine("=== Manage Users and Roles ===");
        Console.WriteLine("1. Assign Role to User");
        Console.WriteLine("2. Remove Role from User");
        Console.WriteLine("3. View Users and Roles");
        Console.WriteLine("4. Return to Admin Menu");

        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        switch (choice)
        {
            case 1:
                Console.WriteLine("Assigning Role To User...");
                AssignRoleToUser();
                break;
            case 2:
                Console.WriteLine("Removing Role From User...");
                RemoveRoleFromUser();
                break;
            case 3:
                Console.WriteLine("Viewing All Users & Roles...");
                ViewUsersAndRoles();
                break;
            case 4:
                Console.WriteLine("Returning to Admin Menu...");
                break;
            default:
                Console.WriteLine("Invalid selection. Try again.");
                break;
        }
    }

    static void AssignRoleToUser()
    {
        Console.Write("Enter User ID: ");
        if (!int.TryParse(Console.ReadLine(), out int userId))
        {
            Console.WriteLine("Invalid User ID.");
            return;
        }

        Console.Write("Enter Role ID to assign: ");
        if (!int.TryParse(Console.ReadLine(), out int roleId))
        {
            Console.WriteLine("Invalid Role ID.");
            return;
        }

        using (var context = new MotorSports_2Context())
        {
            var user = context.Users
                              .Include(u => u.Roles)  // Include roles to make sure we're checking the latest roles
                              .FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            var role = context.Roles.Find(roleId);
            if (role == null)
            {
                Console.WriteLine("Role not found.");
                return;
            }

            if (user.Roles.Any(r => r.RoleId == roleId))
            {
                Console.WriteLine("This role is already assigned to the user.");
                return;
            }

            // If role is not already assigned, add it
            user.Roles.Add(role);

            try
            {
                context.SaveChanges();
                Console.WriteLine("Role assigned successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while assigning role: {ex.Message}");
            }
        }
    }



    static void RemoveRoleFromUser()
    {
        Console.Write("Enter User ID: ");
        if (!int.TryParse(Console.ReadLine(), out int userId))
        {
            Console.WriteLine("Invalid User ID.");
            return;
        }

        Console.Write("Enter Role ID to remove: ");
        if (!int.TryParse(Console.ReadLine(), out int roleId))
        {
            Console.WriteLine("Invalid Role ID.");
            return;
        }

        using (var context = new MotorSports_2Context())
        {
            var user = context.Users.Include(u => u.Roles).FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            var role = user.Roles.FirstOrDefault(r => r.RoleId == roleId);
            if (role == null)
            {
                Console.WriteLine("Role not assigned to this user.");
                return;
            }

            user.Roles.Remove(role);
            context.SaveChanges();

            Console.WriteLine("Role removed successfully.");
        }
    }

    static void ViewUsersAndRoles()
    {
        using (var context = new MotorSports_2Context())
        {
            var users = context.Users
                .Select(u => new
                {
                    u.UserId,
                    u.FirstName,
                    u.LastName,
                    Roles = string.Join(", ", u.Roles.Select(r => r.RoleName))
                })
                .ToList();

            Console.WriteLine("=== List of Users and Their Roles ===");
            foreach (var user in users)
            {
                Console.WriteLine($"User ID: {user.UserId}, Name: {user.FirstName} {user.LastName}, Roles: {user.Roles}");
            }
        }
    }

    static void ManageEventStatuses()
    {
        Console.WriteLine("=== Manage Event Statuses ===");
        Console.WriteLine("1. Set Event Status");
        Console.WriteLine("2. View Event Statuses");
        Console.WriteLine("3. Return to Admin Menu");

        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        switch (choice)
        {
            case 1:
                Console.WriteLine("Setting Event Status...");
                SetEventStatus();
                break;
            case 2:
                Console.WriteLine("Viewing Event Statuses...");
                ViewEventStatuses();
                break;
            case 3:
                Console.WriteLine("Returning to Admin Menu...");
                break;
            default:
                Console.WriteLine("Invalid selection. Try again.");
                break;
        }
    }

    static void SetEventStatus()
    {
        Console.Write("Enter Event ID: ");
        if (!int.TryParse(Console.ReadLine(), out int eventId))
        {
            Console.WriteLine("Invalid Event ID.");
            return;
        }

        Console.Write("Enter Status ID (1 = Scheduled, 2 = Canceled, etc.): ");
        if (!int.TryParse(Console.ReadLine(), out int statusId))
        {
            Console.WriteLine("Invalid Status ID.");
            return;
        }

        using (var context = new MotorSports_2Context())
        {
            var eventRecord = context.Events.Find(eventId);
            if (eventRecord == null)
            {
                Console.WriteLine("Event not found.");
                return;
            }

            var status = context.Statuses.Find(statusId);
            if (status == null)
            {
                Console.WriteLine("Status not found.");
                return;
            }

            eventRecord.StatusId = statusId;
            context.SaveChanges();

            Console.WriteLine("Event status updated successfully.");
        }
    }

    static void ViewEventStatuses()
    {
        using (var context = new MotorSports_2Context())
        {
            var events = context.Events
                .Select(e => new
                {
                    e.EventId,
                    e.EventName,
                    EventDate = e.EventDate.ToString("yyyy-MM-dd"),
                    Status = e.Status != null ? e.Status.StatusName : "No status set"
                })
                .ToList();

            Console.WriteLine("\n=== List of Events and Their Statuses ===");
            foreach (var e in events)
            {
                Console.WriteLine($"Event ID: {e.EventId}, Event Name: {e.EventName}, Event Date: {e.EventDate}, Status: {e.Status}");
            }
        }
    }

    //============================================================================================================================================

}


