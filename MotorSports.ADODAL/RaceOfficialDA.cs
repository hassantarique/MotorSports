using Azure.Core.GeoJson;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSports.ADODAL
{
    public class RaceOfficialDA
    {
        private SqlConnection GetConnection()
        {
            string connectionString = "Data Source=DESKTOP-T143SR9;Initial Catalog=MotorSportTestDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

        public void ViewRaceStandingsSP()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ViewRaceStandings", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("Id: {0}", reader["Id"]);
                                Console.WriteLine("DriverName: {0}", reader["DriverName"]);
                                Console.WriteLine("Position: {0}", reader["Position"]);
                                Console.WriteLine("Points: {0}", reader["Points"]);
                                Console.WriteLine(new string('-', 50));
                            }
                        }
                        else
                        {
                            Console.WriteLine("No race standings found.");
                        }
                    }
                }
            }
        }

        public void PositionAssignment(int driverId, int newPosition)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string checkDriverQuery =
                    @"SELECT
                           COUNT (1) 
                     FROM
                        [RaceStandings] 
                     WHERE 
                         Id = @DriverId;";

                using (SqlCommand checkCommand = new SqlCommand(@checkDriverQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@DriverId", driverId);
                    int driverExists = (int)checkCommand.ExecuteScalar();

                    if (driverExists == 0)
                    {
                        Console.WriteLine("Driver Not Found");
                        return;
                    }
                }

                string query =
                    @"UPDATE 
                            [RaceStandings]
                     SET 
                        Position = @NewPosition 
                     WHERE
                          Id = @DriverId";

                using SqlCommand command = new SqlCommand(query, connection);
                {
                    command.Parameters.AddWithValue("@DriverId", driverId);
                    command.Parameters.AddWithValue("@NewPosition", newPosition);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Position Updated Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Please Check Input.");
                    }
                }

            }
        }

    }
}
