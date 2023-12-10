using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_1___SQL.Methods.Staff
{
    internal class HireNewStaff
    {
        public static void HireStaff()
        {
            Console.Clear();
            Console.WriteLine("What should we call the new recruit? \n As a bonus add a Prefix before the last name. ex. 'Mr Fjellstrom' :");
            string staffprefixName = Console.ReadLine();

            Console.Write("Profession(ex Teacher, Administrator, Principal): ");
            string staffProfession = Console.ReadLine();

            string connectionString = "Data Source=(localdb)\\.;Initial Catalog=ChasAcademy;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                
                string insertQuery = "INSERT INTO SchoolStaff (Last_Name, Profession) VALUES (@Last_Name, @Profession)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Last_Name", staffprefixName);
                    command.Parameters.AddWithValue("@Profession", staffProfession);

                    try //Error handling
                    {
                        int rowsAffected = command.ExecuteNonQuery(); 

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("New staffmember added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add a new staff member. Please try again.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

        }
    }
}
