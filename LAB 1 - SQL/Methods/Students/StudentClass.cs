using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_1___SQL.Methods.Students
{
    internal class StudentClass
    {

        public static void ListStudentsInClasses()
        {
            string connectionString = "Data Source=(localdb)\\.;Initial Catalog=ChasAcademy;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.Clear();
                Console.WriteLine("List of classes:");
                string classQuery = "SELECT * FROM Classes";

                using (SqlCommand classCommand = new SqlCommand(classQuery, connection))
                {
                    using (SqlDataReader classReader = classCommand.ExecuteReader())
                    {
                        while (classReader.Read())
                        {   
                            Console.WriteLine($"{classReader["ClassID"]}. {classReader["ClassName"]}");
                        }
                    }
                }


                Console.Write("Enter the ClassID to see all students in the class: ");
                string classID = Console.ReadLine();

                
                string studentQuery = "SELECT First_Name, Last_Name, Classes.ClassName FROM Students " +
                                      "JOIN Classes ON Classes.ClassID = Students.ClassID " +
                                      "WHERE Classes.ClassID = @ClassID";


                using (SqlCommand studentCommand = new SqlCommand(studentQuery, connection))
                {
                    studentCommand.Parameters.AddWithValue("@ClassID", classID);

                    using (SqlDataReader studentReader = studentCommand.ExecuteReader())
                    {
                        Console.WriteLine();

                        Console.WriteLine($"List of students in Class {classID}:");
                        while (studentReader.Read())
                        {

                            Console.WriteLine($"{studentReader["First_Name"]}, {studentReader["Last_Name"]}");
                        }
                    }
                }
            }
        }
    }
}
