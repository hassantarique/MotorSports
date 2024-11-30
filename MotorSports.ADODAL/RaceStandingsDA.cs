using Microsoft.Data.SqlClient;
using MotorSports.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSports.ADODAL
{
    public class RaceStandingsDA
    {
        private SqlConnection GetConnection()
        {
            string connectionString = "Data Source=DESKTOP-T143SR9;Initial Catalog=MotorSportTestDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

        public List<RaceStanding> ViewRaceStandingsSP()
        {
            List<RaceStanding> standings = new List<RaceStanding>();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ViewRaceStandings", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No race standings found.");
                            return standings;
                        }

                        while (reader.Read())
                        {
                            RaceStanding standing = new RaceStanding
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                DriverName = reader["DriverName"].ToString(),
                                Position = Convert.ToInt32(reader["Position"]),
                                Points = Convert.ToInt32(reader["Points"])
                            };

                            standings.Add(standing);
                        }
                    }
                }
            }

            return standings;
        }


    }
}
