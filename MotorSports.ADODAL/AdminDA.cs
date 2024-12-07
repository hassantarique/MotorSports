using Microsoft.Data.SqlClient;
using MotorSports.DomainObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSports.ADODAL
{
    public class AdminDA
    {
        private SqlConnection GetConnection()
        {
            string connectionString = "Data Source=DESKTOP-T143SR9;Initial Catalog=MotorSportTestDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

        public void RoleAssignment(int userId, int roleId)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string validateRoleQuery =
                    @"SELECT
                            COUNT(*)
                      FROM
                          Roles
                      WHERE
                           RoleID = @RoleID";

                using (SqlCommand validateRoleCommand = new SqlCommand(validateRoleQuery, connection))
                {
                    validateRoleCommand.Parameters.AddWithValue("@RoleID", roleId);

                    int roleExists = (int)validateRoleCommand.ExecuteScalar();
                    if (roleExists == 0)
                    {
                        Console.WriteLine("Invalid Role ID. Role does not exist.");
                        return;
                    }
                }

                string checkUserRoleQuery =
                    @"SELECT
                            COUNT(*)
                      FROM
                          UserRoles 
                      WHERE
                           UserID = @UserID 
                      AND
                         RoleID = @RoleID";

                using (SqlCommand checkUserRoleCommand = new SqlCommand(checkUserRoleQuery, connection))
                {
                    checkUserRoleCommand.Parameters.AddWithValue("@UserID", userId);
                    checkUserRoleCommand.Parameters.AddWithValue("@RoleID", roleId);

                    int userRoleExists = (int)checkUserRoleCommand.ExecuteScalar();
                    if (userRoleExists > 0)
                    {
                        Console.WriteLine("This user already has the specified role.");
                        return;
                    }
                }

                string insertRoleQuery =
                    @"INSERT INTO 
                                UserRoles (UserID, RoleID)
                     VALUES 
                           (@UserID, @RoleID)";
                using (SqlCommand insertRoleCommand = new SqlCommand(insertRoleQuery, connection))
                {
                    insertRoleCommand.Parameters.AddWithValue("@UserID", userId);
                    insertRoleCommand.Parameters.AddWithValue("@RoleID", roleId);

                    int rowsAffected = insertRoleCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Role assigned successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to assign role.");
                    }
                }
            }
        }

        public void RoleRemoval(int userId, int roleId)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string checkUserRoleQuery =
                    @"SELECT
                            COUNT(*) 
                      FROM
                          UserRoles 
                      WHERE
                           UserID = @UserID
                      AND
                         RoleID = @RoleID";
                using (SqlCommand checkUserRoleCommand = new SqlCommand(checkUserRoleQuery, connection))
                {
                    checkUserRoleCommand.Parameters.AddWithValue("@UserID", userId);
                    checkUserRoleCommand.Parameters.AddWithValue("@RoleID", roleId);

                    int userRoleExists = (int)checkUserRoleCommand.ExecuteScalar();
                    if (userRoleExists == 0)
                    {
                        Console.WriteLine("The specified user does not have this role assigned.");
                        return;
                    }
                }

                string deleteRoleQuery =
                    @"DELETE FROM 
                                UserRoles 
                     WHERE
                          UserID = @UserID
                     AND
                        RoleID = @RoleID";
                using (SqlCommand deleteRoleCommand = new SqlCommand(deleteRoleQuery, connection))
                {
                    deleteRoleCommand.Parameters.AddWithValue("@UserID", userId);
                    deleteRoleCommand.Parameters.AddWithValue("@RoleID", roleId);

                    int rowsAffected = deleteRoleCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Role removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to remove the role.");
                    }
                }
            }
        }

        public List<User> ViewAllRolesSP()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ViewAllRoles", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                UserId = reader.GetInt32(reader.GetOrdinal("UserID")),
                                Username = reader.GetString(reader.GetOrdinal("Username")),
                                PaswordHash = reader.GetString(reader.GetOrdinal("PaswordHash")),
                                Email = reader.GetString(reader.GetOrdinal("EMail")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            };
                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        public void SetEventStatusDA(int eventId, int statusId)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string query =
                    @" UPDATE
                             Events
                       SET
                          StatusID = @StatusID
                       WHERE
                            EventID = @EventID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {


                    command.Parameters.AddWithValue("@EventID", eventId);
                    command.Parameters.AddWithValue("@StatusID", statusId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Event ID {eventId} successfully updated with Status ID {statusId}.");
                    }
                    else
                    {
                        Console.WriteLine("No matching Event found or no changes were made.");
                    }
                }
            }
        }

        public void ViewStatuses()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string query =
                    @" SELECT 
                            e.EventID,
                            e.EventName,
                            e.EventDate,
                            e.TotalLaps,
                            s.StatusName
                      FROM 
                          Events e
                     LEFT JOIN 
                              Status s ON e.StatusID = s.StatusID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("Event ID: {0}", reader["EventID"]);
                                Console.WriteLine("Event Name: {0}", reader["EventName"]);
                                Console.WriteLine("Event Date: {0}", reader["EventDate"]);
                                Console.WriteLine("Total Laps: {0}", reader["TotalLaps"]);
                                Console.WriteLine("Status: {0}", reader["StatusName"] ?? "No Status Assigned");
                                Console.WriteLine(new string('-', 50));
                            }
                        }
                        else
                        {
                            Console.WriteLine("No events found.");
                        }
                    }
                }
            }
        }

        public void ViewAllStatusesSP()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ViewAllStatuses", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("Event ID: {0}", reader["EventID"]);
                                Console.WriteLine("Event Name: {0}", reader["EventName"]);
                                Console.WriteLine("Event Date: {0}", reader["EventDate"]);
                                Console.WriteLine("Total Laps: {0}", reader["TotalLaps"]);
                                Console.WriteLine("Status: {0}", reader["StatusName"] ?? "No Status Assigned");
                                Console.WriteLine(new string('-', 50));
                            }
                        }
                        else
                        {
                            Console.WriteLine("No events found.");
                        }
                    }
                }
            }
        }

    }
}
