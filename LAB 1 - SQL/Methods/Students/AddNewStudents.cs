using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_1___SQL.Methods.Students
{
    internal class AddNewStudents
    {
        public static void EnrollStudent()
        {
            Console.Clear();
            Console.WriteLine("Please enter following details to add new student: ");

            Console.Write("Firstname: ");
            string studentFirst_Name = Console.ReadLine();

            Console.Write("Lastname: ");
            string studentLast_Name = Console.ReadLine();

            Console.Write("Age: ");
            int studentAge = int.Parse(Console.ReadLine());

            Console.Write("class ID: ");
            int classID = int.Parse(Console.ReadLine());

            string connectionString = "Data Source=(localdb)\\.;Initial Catalog=ChasAcademy;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                
                string insertQuery = "INSERT INTO Students (First_Name, Last_Name, Age, ClassID) " +
                                     "VALUES (@First_Name, @Last_Name, @Age, @ClassID)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    
                    command.Parameters.AddWithValue("@First_Name", studentFirst_Name);
                    command.Parameters.AddWithValue("@Last_Name", studentLast_Name);
                    command.Parameters.AddWithValue("@Age", studentAge);
                    command.Parameters.AddWithValue("@ClassID", classID);

                    try 
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("New student added successfully, Welcome new blood!");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add a new student. Please try again.");
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
