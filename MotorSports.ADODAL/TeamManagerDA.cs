using Microsoft.Data.SqlClient;
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

        public void ViewAllPlayersSP()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand("ViewAllPlayers", connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine("No Participants Found.");
                    }

                    while (reader.Read())
                    {
                        Console.WriteLine("ParticipantID: {0}", reader["ParticipantID"]);
                        Console.WriteLine("UserID: {0}", reader["UserID"]);
                        Console.WriteLine("LicenseNumber: {0}", reader["LicenseNumber"]);
                        Console.WriteLine("TeamID: {0}", reader["TeamID"]);
                        Console.WriteLine(new string('-', 50));
                    }
                }
            }
        }

        public void ViewPlayerPerformasSP(int eventParticipantId)
        {
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
                                Console.WriteLine("EventParticipantId: {0}", reader["EventParticipantId"]);
                                Console.WriteLine("EventId: {0}", reader["EventId"]);
                                Console.WriteLine("TeamId: {0}", reader["TeamId"]);
                                Console.WriteLine("RaceResultId: {0}", reader["RaceResultId"]);
                                Console.WriteLine("Position: {0}", reader["Position"]);
                                Console.WriteLine("LapTime: {0}", reader["LapTime"]);
                                Console.WriteLine("FinishTime: {0}", reader["FinishTime"]);
                                Console.WriteLine(new string('-', 50));
                            }
                        }
                        else
                        {
                            Console.WriteLine("No records found for the given EventParticipantId.");
                        }
                    }
                }
            }
        }

    }
}
