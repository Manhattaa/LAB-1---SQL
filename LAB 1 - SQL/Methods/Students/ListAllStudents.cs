using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_1___SQL.Methods.Students
{
    internal class ListAllStudents
    {
        public static void ListStudents()
        {
            string connectionString = "Data Source=(localdb)\\.;Initial Catalog=ChasAcademy;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                Console.Clear();
                Console.WriteLine("Choose sorting order:");
                Console.WriteLine("1. Sort by First Name (Ascending)");
                Console.WriteLine("2. Sort by First Name (Descending)");
                Console.WriteLine("3. Sort by Last Name (Ascending)");
                Console.WriteLine("4. Sort by Last Name (Descending)");

                Console.Write("Enter your choice: ");
                int sortChoice = int.Parse(Console.ReadLine());

                string sortBy = "";
                string sOrder = "";

                
                switch (sortChoice)
                {
                    case 1:
                        sortBy = "First_Name";
                        sOrder = "ASC";
                        break;
                    case 2:
                        sortBy = "First_Name";
                        sOrder = "DESC";
                        break;
                    case 3:
                        sortBy = "Last_Name";
                        sOrder = "ASC";
                        break;
                    case 4:
                        sortBy = "Last_Name";
                        sOrder = "DESC";
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Defaulting to sort by First Name (Ascending).");
                        sortBy = "First_Name";
                        sOrder = "ASC";
                        break;
                }

                
                string studentQuery = $"SELECT * FROM Students ORDER BY {sortBy} {sOrder}";

                using (SqlCommand command = new SqlCommand(studentQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.Clear();
                        Console.WriteLine("List of all students:");
                        Console.WriteLine();
                        while (reader.Read())
                        {
                            
                            Console.WriteLine($"{reader["StudentID"]}, {reader["First_Name"]}, {reader["Last_Name"]}");
                        }
                    }
                }
            }
        }
    }
}
