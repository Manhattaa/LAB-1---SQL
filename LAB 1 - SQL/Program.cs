using LAB_1___SQL.Methods.GradesAndClasses;
using LAB_1___SQL.Methods.Staff;
using LAB_1___SQL.Methods.Students;

namespace LAB_1___SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChasMenu();
        }
        
        public static void ChasMenu()
        {
            Console.WriteLine("Welcome to the Chas Academy database!");
            Console.WriteLine("\nPlease choose one of the following options");
            Console.WriteLine("[1] View all Chas Academy students");
            Console.WriteLine("[2] View all students in certain classes");
            Console.WriteLine("[3] Hire new staff");
            Console.WriteLine("[4] List all hired Staff");
            Console.WriteLine("[5] View all grades set in the 30 days");
            Console.WriteLine("[6] Average grade per course");
            Console.WriteLine("[7] Enroll a new student to the database");
            Console.WriteLine("[0] Exit the Program");

            Console.Write("\n Choose your option by entering a valid number: ");
            int menu = int.Parse(Console.ReadLine());

            //Here comes the menu!
            switch (menu)
            {
                case 1:
                    ListAllStudents.ListStudents();
                    break;
                case 2:
                    StudentClass.ListStudentsInClasses();
                    break;
                case 3:
                    HireNewStaff.HireStaff();
                    break;
                case 4:
                    ListAllStaff.ListStaff();
                    break;
                case 5:
                    ListGrades.ThirtyDayGrades();
                    break;
                case 6:
                    AvgGrade.ListAvgGrades();
                    break;
                case 7:
                    AddNewStudents.EnrollStudent();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;

            }
        }
    }
}
