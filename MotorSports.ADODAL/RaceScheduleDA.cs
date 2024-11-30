using Microsoft.Data.SqlClient;
using MotorSports.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSports.ADODAL
{
    public class RaceScheduleDA
    {
        private SqlConnection GetConnection()
        {
            string connectionString = "Data Source=DESKTOP-T143SR9;Initial Catalog=MotorSportTestDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

        public List<RaceSchedule> ViewRaceScheduleSP()
        {
            List<RaceSchedule> raceSchedules = new List<RaceSchedule>();

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
                            return raceSchedules;
                        }

                        while (reader.Read())
                        {
                            RaceSchedule raceSchedule = new RaceSchedule
                            {
                                EventId = Convert.ToInt32(reader["EventId"]),
                                EventName = reader["EventName"].ToString(),
                                VenueId = Convert.ToInt32(reader["VenueId"]),
                                EventDate = Convert.ToDateTime(reader["EventDate"]),
                                TotalLaps = Convert.ToInt32(reader["TotalLaps"]),
                                StatusId = Convert.ToInt32(reader["StatusId"])
                            };

                            raceSchedules.Add(raceSchedule);
                        }
                    }
                }
            }

            return raceSchedules;
        }

    }
}
