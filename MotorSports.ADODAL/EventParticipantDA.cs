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
        public void RaceRegistration(int eventID, int participantID)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                // Check if the record already exists
                string checkQuery = @"
            SELECT
                  COUNT(1) 
            FROM
                [EventParticipants]
            WHERE
                EventID = @EventID AND ParticipantID = @ParticipantID";

                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@EventID", eventID);
                    checkCommand.Parameters.AddWithValue("@ParticipantID", participantID);

                    int exists = (int)checkCommand.ExecuteScalar();
                    if (exists > 0)
                    {
                        Console.WriteLine("The participant is already registered for this event.");
                        return; // Exit the method if the record already exists
                    }
                }

                // Insert the record if it doesn't exist
                string insertQuery = @"
            INSERT INTO
                       [EventParticipants] (EventID, ParticipantID)
            VALUES 
                  (@EventID, @ParticipantID)";

                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@EventID", eventID);
                    insertCommand.Parameters.AddWithValue("@ParticipantID", participantID);

                    int rowsAffected = insertCommand.ExecuteNonQuery();
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
