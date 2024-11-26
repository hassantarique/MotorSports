using MotoSports.ADODAL;
using MotorSports.DomainObjects;

internal class Program
{
    #region Main
    static void Main(string[] args)
    {
        int userSelection = 0;

        do
        {
            showUserRoles();

            Console.WriteLine("Please enter your role (8 to exit):");

            if (!int.TryParse(Console.ReadLine(), out userSelection) || userSelection < 1 || userSelection > 8)
            {
                if (userSelection != 8)
                {
                    Console.WriteLine("Invalid input! Please enter a valid number between 1 and 8.");
                }
                continue;
            }

            if (userSelection == 8)
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                break;
            }

            Console.WriteLine($"Showing Options For Role {userSelection}...");
            Console.WriteLine("");

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

        } while (true);
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
    #endregion Main

    #region Event Manager
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
                    Console.WriteLine("Assigning Sponsors... ");
                    AssignSponsorToEvent();
                    break;
                case 2:
                    Console.WriteLine("Assigning Team To Event... ");
                    AssignTeamToEvent();
                    break;
                case 3:
                    Console.WriteLine("Exiting... ");
                    break;
                default:
                    Console.WriteLine("Invalid Selection, try again.");
                    break;

            }
        } while (choice != 3);
    }

    static void ShowManagingEventOptions()
    {
        Console.WriteLine("");
        Console.WriteLine("1. Assign Sponsor to Event...");
        Console.WriteLine("2. Assign Team to Event...");
        Console.WriteLine("3. Return to Previous Menu.");
        Console.WriteLine("");
    }

    static void CreateEvent()
    {

        try
        {
            Console.Write("Enter Event Name: ");
            string eventName = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(eventName))
                throw new FormatException("Event Name cannot be empty.");

            Console.Write("Enter Venue ID: ");
            if (!int.TryParse(Console.ReadLine(), out int venueId))
                throw new FormatException("Venue ID must be a valid number.");

            Console.Write("Enter Event Date (yyyy-MM-dd HH:mm:ss): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime eventDate))
                throw new FormatException("Event Date must be in the format yyyy-MM-dd HH:mm:ss.");

            Console.Write("Enter Total Laps: ");
            if (!int.TryParse(Console.ReadLine(), out int totalLaps))
                throw new FormatException("Total Laps must be a valid number.");

            Console.Write("Enter Status ID: ");
            if (!int.TryParse(Console.ReadLine(), out int statusId))
                throw new FormatException("Status ID must be a valid number.");

            EventManagerDA eventManagerDA = new EventManagerDA();
            eventManagerDA.EventCreation(new Event { EventName = eventName, VenueId = venueId, EventDate = eventDate, TotalLaps = totalLaps, StatusId = statusId });
        }

        catch (FormatException ex)
        {
            Console.WriteLine($"Input format error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    static void AssignSponsorToEvent()
    {
        try
        {
            Console.Write("Enter EventId: ");
            if (!int.TryParse(Console.ReadLine(), out int eventId))
            {
                Console.WriteLine("Invalid input for EventId. Please enter a valid number.");
                return;
            }

            Console.Write("Enter SponsorId: ");
            if (!int.TryParse(Console.ReadLine(), out int sponsorId))
            {
                Console.WriteLine("Invalid input for SponsorId. Please enter a valid number.");
                return;
            }

            EventManagerDA sponsorManagerDA = new EventManagerDA();
            sponsorManagerDA.AssignSponsor(sponsorId, eventId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    static void AssignTeamToEvent()
    {
        try
        {
            Console.Write("Enter TeamId: ");
            if (!int.TryParse(Console.ReadLine(), out int teamId))
            {
                Console.WriteLine("Invalid input for TeamId. Please enter a valid number.");
                return;
            }

            Console.Write("Enter EventId: ");
            if (!int.TryParse(Console.ReadLine(), out int eventId))
            {
                Console.WriteLine("Invalid input for EventId. Please enter a valid number.");
                return;
            }

            EventManagerDA teamManagerDA = new EventManagerDA();
            teamManagerDA.AssignTeam(teamId, eventId);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    static void ViewEvents()
    {
        try
        {
            List<Event> events = new EventManagerDA().ViewAllEventsSP();

            if (events.Count > 0)
            {
                foreach (Event e in events)
                {
                    Console.WriteLine("EventId: {0}", e.EventId);
                    Console.WriteLine("EventName: {0}", e.EventName);
                    Console.WriteLine("VenueId: {0}", e.VenueId);
                    Console.WriteLine("EventDate: {0:yyyy-MM-dd HH:mm:ss}", e.EventDate);
                    Console.WriteLine("TotalLaps: {0}", e.TotalLaps);
                    Console.WriteLine("StatusId: {0}", e.StatusId);
                    Console.WriteLine(new string('-', 50));
                }
            }
            else
            {
                Console.WriteLine("No upcoming races found.");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
    #endregion Event Manager

    #region Participant
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
        try
        {
            List<Event> events = new EventManagerDA().ViewAllEventsSP();

            if (events.Count > 0)
            {
                foreach (Event e in events)
                {
                    Console.WriteLine("EventId: {0}", e.EventId);
                    Console.WriteLine("EventName: {0}", e.EventName);
                    Console.WriteLine("VenueId: {0}", e.VenueId);
                    Console.WriteLine("EventDate: {0:yyyy-MM-dd HH:mm:ss}", e.EventDate);
                    Console.WriteLine("TotalLaps: {0}", e.TotalLaps);
                    Console.WriteLine("StatusId: {0}", e.StatusId);
                    Console.WriteLine(new string('-', 50));
                }
            }
            else
            {
                Console.WriteLine("No upcoming races found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    static void RegisterForRace()
    {
        try
        {
            Console.Write("Enter Event ID: ");
            int eventID;
            if (!int.TryParse(Console.ReadLine(), out eventID))
            {
                Console.WriteLine("Invalid input for Event ID.");
                return;
            }

            Console.Write("Enter Team ID: ");
            int teamID;
            if (!int.TryParse(Console.ReadLine(), out teamID))
            {
                Console.WriteLine("Invalid input for Team ID.");
                return;
            }


            EventParticipantDA events = new EventParticipantDA();
            events.RaceRegistration(eventID, teamID);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    static void ViewResults()
    {
        try
        {
            EventParticipantDA eventParticipantDA = new EventParticipantDA();
            List<RaceResult> results = eventParticipantDA.ViewAllResultsSP();

            if (results.Count > 0)
            {
                foreach (RaceResult result in results)
                {
                    Console.WriteLine("EventParticipantId: {0}", result.EventParticipantId);
                    Console.WriteLine("LapTime: {0}", result.LapTime);
                    Console.WriteLine("LapNumber: {0}", result.LapNumber);
                    Console.WriteLine("Position: {0}", result.Position);
                    Console.WriteLine("RaceResultId: {0}", result.RaceResultId);
                    Console.WriteLine(new string('-', 50));
                }
            }
            else
            {
                Console.WriteLine("No race results found.");
            }


        }

        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
    #endregion Participant

    #region Team Manager
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
        try
        {
            Console.WriteLine("Enter UserID: ");
            int userId;
            if (!int.TryParse(Console.ReadLine(), out userId))
            {
                Console.WriteLine("Invalid input for UserId.");
                return;
            }

            Console.WriteLine("Enter TeamID: ");
            int teamId;
            if (!int.TryParse(Console.ReadLine(), out teamId))
            {
                Console.WriteLine("Invalid input for TeamId.");
                return;
            }

            Console.WriteLine("Enter License Number: ");
            int license;
            if (!int.TryParse(Console.ReadLine(), out license))
            {
                Console.WriteLine("Invalid Input For License Number.");
                return;
            }

            TeamManagerDA teamManagerDA = new TeamManagerDA();
            teamManagerDA.PlayerAddition(userId, teamId, license);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        Console.ReadLine();
    }

    static void RemovePlayer()
    {
        try
        {
            int participantId;
            if (!int.TryParse(Console.ReadLine(), out participantId))
            {
                Console.WriteLine("Invalid input for Participant ID.");
                return;
            }

            TeamManagerDA teamManagerDA = new TeamManagerDA();
            teamManagerDA.PlayerRemoval(participantId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while opening the connection: {ex.Message}");
        }
    }

    static void ViewPlayers()
    {
        try
        {
            TeamManagerDA teamManagerDA = new TeamManagerDA();
            teamManagerDA.ViewAllPlayersSP();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void ViewTeamPerformance()
    {
        try
        {
            Console.Write("Enter the EventParticipantId: ");
            int userInput;

            if (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for EventParticipantId.");
                return;
            }

            TeamManagerDA teamManagerDA = new TeamManagerDA();
            teamManagerDA.ViewPlayerPerformasSP(userInput);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    #endregion Team Manager

    #region Spectator
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
            UserDA userDA = new UserDA();
            userDA.ViewRaceScheduleSP();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    static void ViewRaceStandings()
    {
        try
        {
            UserDA userDA = new UserDA();
            userDA.ViewRaceStandingsSP();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
    #endregion Spectator

    #region Race Official
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
        try
        {
            RaceOfficialDA raceOfficialDA = new RaceOfficialDA();
            raceOfficialDA.ViewRaceStandingsSP();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    static void AssignPositions()
    {
        try
        {
            Console.WriteLine("Enter The Driver's Id: ");
            int driverId;
            if (!int.TryParse(Console.ReadLine(), out driverId))
            {
                Console.WriteLine("Invalid Input for Driver Id.");
                return;
            }

            Console.WriteLine("Assign position To Driver: ");
            int newPosition;
            if (!int.TryParse(Console.ReadLine(), out newPosition))
            {
                Console.WriteLine("Invalid Input for Position.");
                return;
            }

            RaceOfficialDA raceOfficialDA = new RaceOfficialDA();
            raceOfficialDA.PositionAssignment(driverId, newPosition);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
    #endregion Race Official

    #region Sponsor
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
        try
        {
            Console.WriteLine("Enter Your SponsorId: ");
            int sponsorId;
            if (!int.TryParse(Console.ReadLine(), out sponsorId))
            {
                Console.WriteLine("Invalid Input For Id.");
                return;
            }

            //Create an instance and call the method.
            List<Event> events = new EventSponsorsDA().ViewSponsoredEventsSP(sponsorId);

            foreach (Event item in events)
            {
                Console.WriteLine("EventId: {0}", item.EventId);
                Console.WriteLine("EventName: {0}", item.EventName);
                Console.WriteLine("VenueId: {0}", item.VenueId);
                Console.WriteLine("EventDate: {0}", item.EventDate);
                Console.WriteLine("TotalLaps: {0}", item.TotalLaps);
                Console.WriteLine("StatusId: {0}", item.StatusId);
                Console.WriteLine(new string('-', 50));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    static void RemoveSponsorship()
    {
        try
        {
            Console.WriteLine("Enter Sponsor Id: ");
            int sponsorID;
            if (!int.TryParse(Console.ReadLine(), out sponsorID))
            {
                Console.WriteLine("Invalid Input for ID.");
            }

            Console.Write("Enter Event ID: ");
            int eventID;
            if (!int.TryParse(Console.ReadLine(), out eventID))
            {
                Console.WriteLine("Invalid input for Event ID.");
                return;
            }

            // Create an instance of SponsorsDA to call RemoveSponsorship method
            EventSponsorsDA eventSponsorsDA = new EventSponsorsDA();

            // Call the method to remove sponsorship
            eventSponsorsDA.RemoveSponsorship(sponsorID, eventID);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
    #endregion Sponsor

    #region Admin
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
                ViewUserRoles();
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
        try
        {
            Console.Write("Enter User ID: ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("Invalid input for User ID.");
                return;
            }

            Console.Write("Enter Role ID: ");
            if (!int.TryParse(Console.ReadLine(), out int roleId))
            {
                Console.WriteLine("Invalid input for Role ID.");
                return;
            }

            AdminDA adminDA = new AdminDA();
            adminDA.RoleAssignment(userId, roleId);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    static void RemoveRoleFromUser()
    {
        try
        {
            Console.Write("Enter User ID: ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("Invalid input for User ID.");
                return;
            }

            Console.Write("Enter Role ID: ");
            if (!int.TryParse(Console.ReadLine(), out int roleId))
            {
                Console.WriteLine("Invalid input for Role ID.");
                return;
            }

            AdminDA adminDA = new AdminDA();
            adminDA.RoleRemoval(userId, roleId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    static void ViewUserRoles()
    {
        try
        {
            AdminDA adminDA = new AdminDA();
            adminDA.ViewAllRolesSP();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
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
        try
        {
            Console.Write("Enter the Event ID: ");
            if (!int.TryParse(Console.ReadLine(), out int eventId))
            {
                Console.WriteLine("Invalid input for Event ID. Please enter a valid number.");
                return;
            }

            Console.Write("Enter the Status ID: ");
            if (!int.TryParse(Console.ReadLine(), out int statusId))
            {
                Console.WriteLine("Invalid input for Status ID. Please enter a valid number.");
                return;
            }

            AdminDA adminDA = new AdminDA();
            adminDA.SetEventStatusDA(eventId, statusId);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    static void ViewEventStatuses()
    {
        try
        {
            AdminDA adminDA = new AdminDA();
            adminDA.ViewAllStatusesSP();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    #endregion Admin

    //============================================================================================================================================
}

