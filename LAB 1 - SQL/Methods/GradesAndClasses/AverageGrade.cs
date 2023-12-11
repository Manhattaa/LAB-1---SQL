using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_1___SQL.Methods.GradesAndClasses
{
    internal class AvgGrade
    {
        public static void ListAvgGrades()
        {
            Console.Clear();
            string connectionString = "Data Source=(localdb)\\.;Initial Catalog=ChasAcademy;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                string query = "SELECT " +
                               "Courses.CourseID, " +
                               "Courses.Course_Name, " +
                               "AVG(CAST(Grades.Grade AS FLOAT)) AS AvgGrade, " +
                               "MAX(Grades.Grade) AS MaxGrade, " +
                               "MIN(Grades.Grade) AS MinGrade " +
                               "FROM Courses " +
                               "LEFT JOIN Grades ON Courses.CourseID = Grades.CourseID ";  

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("CourseID | Course_Name | AvgGrade | MaxGrade | MinGrade");
                        while (reader.Read())
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{reader["CourseID"]} | {reader["Course_Name"]} | {reader["AvgGrade"]} | {reader["MaxGrade"]} | {reader["MinGrade"]}");
                        }
                    }
                }
            }
        }
    }
}
