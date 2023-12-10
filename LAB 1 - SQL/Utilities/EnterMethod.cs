using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_1___SQL.Utilities
{
    internal class EnterMethod
    {
        public static void Enter()
        {
            Console.WriteLine("Press [Enter] to return to the main menu!");
            while (Console.ReadLine() != string.Empty)
            {
                Console.WriteLine("Invalid input [Press Enter] to return to the main menu!");
            }

            Console.Clear();
            Program.ChasMenu();
        }
    }
}
