using Microsoft.Data.SqlClient;
using MotorSports.DomainObjects;

namespace MotoSports.ADODAL
{
    public class EventSponsorsDA
    {
        private SqlConnection GetConnection()
        {
            string connectionString = "Data Source=DESKTOP-T143SR9;Initial Catalog=MotorSportTestDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

        public List<Event> ViewSponsoredEventsSP(int sponsorId)
        {
            List<Event> events = new List<Event>();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ViewSponsoredEvents", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add the parameter for SponsorID
                    command.Parameters.Add(new SqlParameter("@SponsorID", System.Data.SqlDbType.Int)
                    {
                        Value = sponsorId
                    });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                events.Add(new Event
                                {
                                    EventId = Convert.ToInt32(reader["EventId"]),
                                    EventName = reader["EventName"].ToString(),
                                    VenueId = Convert.ToInt32(reader["VenueId"]),
                                    EventDate = (DateTime)reader["EventDate"],
                                    TotalLaps = Convert.ToInt32(reader["TotalLaps"]),
                                    StatusId = Convert.ToInt32(reader["StatusId"]),
                                });
                            }
                        }
                        else
                        {
                            Console.WriteLine("No sponsored events found for the given Sponsor ID.");
                        }
                    }
                }
            }

            return events;
        }

        public void RemoveSponsorship(int sponsorID, int eventID)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string query =
                    @"DELETE FROM
                                [EVENTSPONSORS]
                     WHERE
                          SponsorId = @SponsorId
                     AND
                        EventId = @EventId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SponsorId", sponsorID);
                    command.Parameters.AddWithValue("@EventId", eventID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Sponsorship removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No Sponsorships Found.");
                    }
                }

            }
        }

        public List<Sponsor> GetSponsorsByEventID(int eventID)
        {
            List<Sponsor> sponsors = new List<Sponsor>();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetSponsorsByEventID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add the parameter for EventID
                    command.Parameters.Add(new SqlParameter("@EventID", System.Data.SqlDbType.Int)
                    {
                        Value = eventID
                    });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                sponsors.Add(new Sponsor
                                {
                                    SponsorId = Convert.ToInt32(reader["SponsorID"]),
                                    SponsorName = reader["SponsorName"].ToString(),
                                    ContactInfo = reader["ContactInfo"].ToString(),
                                    SponsorType = reader["SponsorType"].ToString()
                                });
                            }
                        }
                        else
                        {
                            Console.WriteLine("No sponsored events found for the given Sponsor ID.");
                        }
                    }
                }
            }

            return sponsors;
        }

    }

}
