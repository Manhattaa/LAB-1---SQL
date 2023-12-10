using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_1___SQL.Methods.GradesAndClasses
{
    internal class ListGrades
    {
        public static void ThirtyDayGrades()
        {
            string connectionString = "Data Source=(localdb)\\.;Initial Catalog=ChasAcademy;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                DateTime thirtyDays = DateTime.Now.AddMonths(-1);
                string query = $"SELECT Students.First_Name + Students.Last_Name AS Student_Name, Courses.Course_Name, Grades.Grade " +
                               $"FROM Grades " +
                               $"INNER JOIN Students ON Grades.StudentID = Students.StudentID " +
                               $"INNER JOIN Courses ON Grades.CourseID = Courses.CourseID " +
                               $"WHERE Grades.GradeDate >= @LastMonth";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LastMonth", thirtyDays);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.Clear();
                        Console.WriteLine($"List of grades assigned to students in the past 30 days:");
                        Console.WriteLine();
                        Console.WriteLine("Student Name | Course Name | Grade");
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Student_Name"]}, {reader["Course_Name"]}, {reader["Grade"]}");
                        }
                    }
                }
            }
        }
    }
}
