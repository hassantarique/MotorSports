using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSports.ADODAL
{
    public class UserDA
    {
        private SqlConnection GetConnection()
        {
            string connectionString = "Data Source=DESKTOP-T143SR9;Initial Catalog=MotorSportTestDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

        public void ViewRaceScheduleSP()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ViewRaceSchedule", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No upcoming races found.");
                            return;
                        }

                        while (reader.Read())
                        {
                            Console.WriteLine("EventId: {0}", reader["EventId"]);
                            Console.WriteLine("EventName: {0}", reader["EventName"]);
                            Console.WriteLine("VenueId: {0}", reader["VenueId"]);
                            Console.WriteLine("EventDate: {0:yyyy-MM-dd HH:mm:ss}", reader["EventDate"]);
                            Console.WriteLine("TotalLaps: {0}", reader["TotalLaps"]);
                            Console.WriteLine("StatusId: {0}", reader["StatusId"]);
                            Console.WriteLine(new string('-', 50));
                        }
                    }
                }
            }
        }

        public void ViewStandings()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string query =
                    @"SELECT
                        Id,
                        DriverName,
                        Position,
                        Points
                  FROM
                        [RaceStandings]";

                SqlCommand command = new SqlCommand(query, connection);

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

    }
}
