using Microsoft.Data.SqlClient;
using MotorSports.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSports.ADODAL
{
    public class TeamManagerDA
    {
        private SqlConnection GetConnection()
        {
            string connectionString = "Data Source=DESKTOP-T143SR9;Initial Catalog=MotorSportTestDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

        public void PlayerAddition(int userId, int teamId, int license)
        {
            using (SqlConnection connection = GetConnection())
            {

                connection.Open();

                SqlCommand command = new SqlCommand(
                    @"INSERT INTO 
                             [PARTICIPANTS] (UserID, TeamID, LicenseNumber)      
                  VALUES
                        (@UserID, @TeamID, @LicenseNumber)",
                    connection);



                command.Parameters.AddWithValue("@UserID", userId);
                command.Parameters.AddWithValue("@TeamID", teamId);
                command.Parameters.AddWithValue("@LicenseNumber", license);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows affected: {rowsAffected}");

            }
        }

        public void PlayerRemoval(int participantId)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string sql = @"DELETE FROM
                                         [EVENTPARTICIPANTS]
                           WHERE
                                ParticipantID = @ParticipantID";

                Console.Write("Enter Participant ID: ");



                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ParticipantID", participantId);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? "Participant Deleted" : "Participant Not Found");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Database error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            }
        }

        public List<Participant> ViewAllPlayersSP()
        {
            List<Participant> participants = new List<Participant>();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand("ViewAllPlayers", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Participant participant = new Participant
                            {
                                ParticipantId = Convert.ToInt32(reader["ParticipantID"]),
                                UserId = Convert.ToInt32(reader["UserID"]),
                                LicenseNumber = reader["LicenseNumber"].ToString(),
                                TeamId = reader["TeamID"] != DBNull.Value ? Convert.ToInt32(reader["TeamID"]) : (int?)null
                            };

                            participants.Add(participant);
                        }
                    }
                }
            }

            return participants;
        }
 
        public List<RaceResult> ViewPlayerPerformasSP(int eventParticipantId)
        {
            List<RaceResult> results = new List<RaceResult>();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ViewPlayerPerformas", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add the required parameter
                    command.Parameters.Add(new SqlParameter("@EventParticipantId", System.Data.SqlDbType.Int)
                    {
                        Value = eventParticipantId
                    });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                RaceResult result = new RaceResult
                                {
                                    RaceResultId = Convert.ToInt32(reader["RaceResultId"]),
                                    EventParticipantId = Convert.ToInt32(reader["EventParticipantId"]),
                                    LapNumber = Convert.ToInt32(reader["LapNumber"]),
                                    LapTime = TimeOnly.FromTimeSpan((TimeSpan)reader["LapTime"]),
                                    Position = reader["Position"] != DBNull.Value ? Convert.ToInt32(reader["Position"]) : (int?)null
                                };

                                results.Add(result);
                            }
                        }
                    }
                }
            }

            return results;
        }

    }
}
 