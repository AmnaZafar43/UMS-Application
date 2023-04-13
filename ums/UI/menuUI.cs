using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ums.UI
{
    class menuUI
    {
        public static void mainMenu()
        {
            Console.WriteLine("***********************************************");
            Console.WriteLine("*                                             *");
            Console.WriteLine("*                                             *");
            Console.WriteLine("*  UNIVERSITY ADDMISSION MANAGEMENT SYSTEM    *");
            Console.WriteLine("*                                             *");
            Console.WriteLine("*                                             *");
            Console.WriteLine("***********************************************");
        }
        public static void menu()
        {
            Console.WriteLine("1- Add Student");
            Console.WriteLine("2- Add Degree Program");
            Console.WriteLine("3- Generate Merit");
            Console.WriteLine("4- View Registered Subjects");
            Console.WriteLine("5- View Students Of Specific Program");
            Console.WriteLine("6- Register Subjects For a Specific Student");
            Console.WriteLine("7- Calculate Fee For All Register Students");
            Console.WriteLine("8- Exit");
        }
        public static int menuOption()
        {
            menu();
            int option = 0;
            Console.WriteLine("\n\n");
            Console.WriteLine("Enter your option...");
            option = int.Parse(Console.ReadLine());
            return option;
        }
    }
}
