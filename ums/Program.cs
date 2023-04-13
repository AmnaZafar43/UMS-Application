using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ums.BL;
using ums.DL;
using ums.UI;

namespace ums
{
    class Program
    {
        static void Main(string[] args)
        {
            string subjectPath = "subject.txt";
            string degreePath = "degree.txt";
            string studentPath = "student.txt";
            subjectDL.readFromFile(subjectPath);
            degreeProgramDL.readFromFile(degreePath);
            studenDL.readFromFile(studentPath);
            int option;
            do
            {
                menuUI.mainMenu();
                option = menuUI.menuOption();
                Console.Clear();
                if (option == 1)
                {
                    if (degreeProgramDL.programList.Count > 0)
                    {
                        student s = StudentUI.StudentInput();
                        studenDL.addStudenttoList(s);
                        studenDL.storeintoFile(studentPath, s);
                    }
                }
                else if (option == 2)
                {
                    degreeProgram d = DegreeProgramUI.DegreeInput();
                    degreeProgramDL.addIntoDegreeList(d);
                    degreeProgramDL.storeintoFile(degreePath, d);
                }
                else if (option == 3)
                {
                    List<student> sortedStudentList = new List<student>();
                    sortedStudentList = studenDL.sortStudentsByMerit();
                    studenDL.giveAdmission(sortedStudentList);
                    StudentUI.printStudents();
                }
                else if (option == 4)
                {
                    StudentUI.RegisteredStudents();
                }
                else if (option == 5)
                {
                    string degName;
                    Console.Write("Enter Degree Name: ");
                    degName = Console.ReadLine();
                    StudentUI.viewStudentInDegree(degName);
                }
                else if (option == 6)
                {
                    Console.Write("Enter the Student Name: ");
                    string name = Console.ReadLine();
                    student s = studenDL.StudentPresent(name);
                    if (s != null)
                    {
                        subjectUI.Subjectsview(s);
                        subjectUI.registerSubjects(s);
                    }
                }
                else if (option == 7)
                {
                    StudentUI.calculateFeeForAll();
                }
                Console.Clear();
            }
            while (option < 8);
            Console.ReadKey();
        }

    }

}