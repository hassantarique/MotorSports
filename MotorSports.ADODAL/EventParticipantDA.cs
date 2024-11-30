using Microsoft.Data.SqlClient;
using MotorSports.DomainObjects;

namespace MotoSports.ADODAL
{
    public class EventParticipantDA
    {
        private SqlConnection GetConnection()
        {
            string connectionString = "Data Source=DESKTOP-T143SR9;Initial Catalog=MotorSportTestDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }
        public void RaceRegistration(int eventID, int teamID)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string query =
                    @"INSERT INTO
                                 [EventParticipants] (EventID,
                                                      TeamID )
                      VALUES
                            (@EventID, @TeamID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventID", eventID);

                    command.Parameters.AddWithValue("TeamID", teamID);

                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Rows affected: {rowsAffected}");
                }
            }
        }

        public List<RaceResult> ViewAllResultsSP()
        {
            List<RaceResult> results = new List<RaceResult>();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ViewRaceResults", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Console.WriteLine("No Results Found.");
                        }

                        while (reader.Read())
                        {
                            results.Add(new RaceResult
                            {
                                EventParticipantId = Convert.ToInt32(reader["EventParticipantID"]),
                                LapTime = TimeOnly.FromTimeSpan((TimeSpan)reader["LapTime"]),
                                LapNumber = Convert.ToInt32(reader["LapNumber"]),
                                Position = Convert.ToInt32(reader["Position"]),
                                RaceResultId = Convert.ToInt32(reader["RaceResultId"])
                            }

                            );
                        }
                    }
                }
            }

            return results;
        }

    }
}
