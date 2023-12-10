using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_1___SQL.Methods.Staff
{
    internal class ListAllStaff
    {
        public static void ListStaff()
        {
            string connectionString = "Data Source=(localdb)\\.;Initial Catalog=ChasAcademy;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
              
                Console.Clear();
                Console.WriteLine("1. View all staff members");
                Console.WriteLine("2. View staff members by profession");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    ViewAllStaffWithoutFilter(connection);
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Principal");
                    Console.WriteLine("Administrator");
                    Console.WriteLine("Teacher");
                    Console.WriteLine("Janitor");
                    Console.Write("Enter profession (or leave blank to view all): ");
                    string selectedProfession = Console.ReadLine();

                    ViewStaffByProfession(connection, selectedProfession);
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }

            static void ViewAllStaffWithoutFilter(SqlConnection connection)
            {
                string query = "SELECT * FROM SchoolStaff";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("List of all staff members on school:");
                        while (reader.Read())
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{reader["StaffID"]}, {reader["Last_Name"]}, {reader["Profession"]}");
                        }
                    }
                }
            }

            static void ViewStaffByProfession(SqlConnection connection, string selectedProfession)
            {
                Console.Clear();
                string query = "SELECT * FROM SchoolStaff WHERE Profession = @Profession";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Profession", selectedProfession);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine($"List of staff members with employment {selectedProfession}:");
                        while (reader.Read())
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{reader["StaffID"]}. {reader["Last_Name"]}, {reader["Profession"]}");
                        }
                    }
                }
            }
        }
    }
}
