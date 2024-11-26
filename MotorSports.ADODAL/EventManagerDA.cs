using Microsoft.Data.SqlClient;
using MotorSports.DomainObjects;

namespace MotoSports.ADODAL
{
    public class EventManagerDA
    {
        private SqlConnection GetConnection()
        {
            string connectionString = "Data Source=DESKTOP-T143SR9;Initial Catalog=MotorSportTestDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

        public void EventCreation(Event newEvent)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(
                    @"INSERT INTO
                                 [EVENTS] (EventName,
                                           VenueId,
                                           EventDate,
                                           TotalLaps,
                                           StatusId)
                      VALUES
                            (@EventName, @VenueId, @EventDate, @TotalLaps, @StatusId)", connection))
                {

                    command.Parameters.Add(new SqlParameter("@EventName", System.Data.SqlDbType.NVarChar) { Value = newEvent.EventName });

                    command.Parameters.Add(new SqlParameter("@VenueId", System.Data.SqlDbType.Int) { Value = newEvent.VenueId });

                    command.Parameters.Add(new SqlParameter("@EventDate", System.Data.SqlDbType.DateTime) { Value = newEvent.EventDate });

                    command.Parameters.Add(new SqlParameter("@TotalLaps", System.Data.SqlDbType.Int) { Value = newEvent.TotalLaps });

                    command.Parameters.Add(new SqlParameter("@StatusId", System.Data.SqlDbType.Int) { Value = newEvent.StatusId });

                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Event created successfully. Rows affected: {rowsAffected}");
                }
            }

        }

        public void AssignSponsor(int sponsorId, int eventId)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();



                using (SqlCommand checkSponsorCommand = new SqlCommand(
                    @"SELECT 
                            COUNT(1)
                     FROM
                         [Sponsors]
                     WHERE
                          SponsorId = @SponsorId", connection))
                {
                    checkSponsorCommand.Parameters.Add(new SqlParameter("@SponsorId", System.Data.SqlDbType.Int) { Value = sponsorId });
                    int sponsorExists = (int)checkSponsorCommand.ExecuteScalar();

                    if (sponsorExists == 0)
                    {
                        Console.WriteLine("Sponsor does not exist.");
                        return;
                    }
                }

                using (SqlCommand checkEventCommand = new SqlCommand(
                    @"SELECT
                            COUNT(1) 
                      FROM
                          [Events]
                      WHERE 
                           EventId = @EventId", connection))
                {
                    checkEventCommand.Parameters.Add(new SqlParameter("@EventId", System.Data.SqlDbType.Int) { Value = eventId });
                    int eventExists = (int)checkEventCommand.ExecuteScalar();

                    if (eventExists == 0)
                    {
                        Console.WriteLine("Event does not exist.");
                        return;
                    }
                }

                using (SqlCommand command = new SqlCommand(
                    @"INSERT INTO
                                 [EventSponsors] (EventId, SponsorId)
                      VALUES
                            (@EventId, @SponsorId)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@EventId", System.Data.SqlDbType.Int) { Value = eventId });
                    command.Parameters.Add(new SqlParameter("@SponsorId", System.Data.SqlDbType.Int) { Value = sponsorId });

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Sponsor assigned successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to assign the sponsor. Please try again.");
                    }
                }
            }
        }

        public void AssignTeam(int teamId, int eventId)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();



                using (SqlCommand checkTeamCommand = new SqlCommand(
                    @"SELECT
                            COUNT(1)
                      FROM 
                          [Teams]
                      WHERE
                           TeamId = @TeamId", connection))
                {
                    checkTeamCommand.Parameters.Add(new SqlParameter("@TeamId", System.Data.SqlDbType.Int) { Value = teamId });
                    int teamExists = (int)checkTeamCommand.ExecuteScalar();

                    if (teamExists == 0)
                    {
                        Console.WriteLine("Team does not exist.");
                        return;
                    }
                }

                using (SqlCommand checkEventCommand = new SqlCommand(
                    @"SELECT 
                            COUNT(1)
                      FROM
                          [Events] 
                      WHERE 
                           EventId = @EventId", connection))
                {
                    checkEventCommand.Parameters.Add(new SqlParameter("@EventId", System.Data.SqlDbType.Int) { Value = eventId });
                    int eventExists = (int)checkEventCommand.ExecuteScalar();

                    if (eventExists == 0)
                    {
                        Console.WriteLine("Event does not exist.");
                        return;
                    }
                }

                using (SqlCommand command = new SqlCommand(
                    @"INSERT INTO 
                                 [EventParticipants] (EventId, TeamId) 
                      VALUES
                            (@EventId, @TeamId)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@EventId", System.Data.SqlDbType.Int) { Value = eventId });
                    command.Parameters.Add(new SqlParameter("@TeamId", System.Data.SqlDbType.Int) { Value = teamId });

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Team assigned successfully to the event.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to assign the team. Please try again.");
                    }
                }
            }
        }

        public List<Event> ViewAllEventsSP()
        {
            List<Event> events = new List<Event>();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                // Use SqlCommand to call the stored procedure
                using (SqlCommand command = new SqlCommand("ViewAllEvents", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No events found.");
                        }

                        while (reader.Read())
                        {
                            events.Add(new Event
                            {
                                EventId = Convert.ToInt32(reader["EventId"]),
                                EventName = reader["EventName"].ToString(),
                                VenueId = Convert.ToInt32(reader["VenueId"]),
                                EventDate = (DateTime)reader["EventDate"],
                                TotalLaps = Convert.ToInt32(reader["TotalLaps"]),
                                StatusId = Convert.ToInt32(reader["StatusId"])
                            });
                        }
                    }
                }
            }

            return events;
        }


    }
}
