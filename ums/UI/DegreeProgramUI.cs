using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ums.BL;
using ums.DL;

namespace ums.UI
{
    class DegreeProgramUI
    {
        public static degreeProgram DegreeInput()
        {
            string degree_n;
            float degree_D;
            int seat;
            Console.Write("Enter Degree Name ");
            degree_n = Console.ReadLine();
            Console.Write("Enter Duration of Degree : ");
            degree_D = float.Parse(Console.ReadLine());
            Console.Write("Enter Seats of Degree: ");
            seat = int.Parse(Console.ReadLine());

            degreeProgram degProg = new degreeProgram(degree_n, degree_D, seat);
            Console.Write("Enter number of Subjects : ");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                subject s = subjectUI.takeSubject();
                if (degProg.AddSubject(s))
                {
                    if (!(subjectDL.subjectList.Contains(s)))
                    {
                        subjectDL.addSubjectIntoList(s);
                        subjectDL.storeintoFile("subject.txt", s);
                    }
                    Console.WriteLine("Subject Added");
                }
                else
                {
                    Console.WriteLine("OOP sorry ! subject Not Added");
                    Console.WriteLine("20 credit hour limit exceeded");
                    x--;
                }
            }
            return degProg;
        }
        public static void viewDegPrograms()
        {
            foreach (degreeProgram dp in degreeProgramDL.programList)
            {
                Console.WriteLine(dp.degreeName);
            }
            Console.ReadKey();
        }
    }
}
