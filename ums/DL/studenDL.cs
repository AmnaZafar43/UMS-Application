using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ums.BL;
using ums.DL;

namespace ums.DL
{
    class studenDL
    {
        public static List<student> student = new List<student>();

        public static void addStudenttoList(student s)
        {
            student.Add(s);
        }

        public static student StudentPresent(string name)
        {
            foreach (student s in student)
            {
                if (name == s.name && s.regDegree != null)
                {
                    return s;
                }
            }
            return null;
        }

        public static List<student> sortStudentsByMerit()
        {
            List<student> sortedStudentList = new List<student>();
            foreach (student s in student)
            {
                s.calculateMerit();
            }
            sortedStudentList = student.OrderByDescending(o => o.merit).ToList();
            return sortedStudentList;
        }

        public static void giveAdmission(List<student> sortedStudentList)
        {
            foreach (student s in sortedStudentList)
            {
                foreach (degreeProgram d in s.preferences)
                {
                    if (d.seats > 0 && s.regDegree == null)
                    {
                        s.regDegree = d;
                        d.seats--;
                        break;
                    }
                }
            }
        }
        public static void storeintoFile(string path, student s)
        {
            StreamWriter f = new StreamWriter(path, true);
            string degreeNames = "";
            for (int x = 0; x < s.preferences.Count - 1; x++)
            {
                degreeNames = degreeNames + s.preferences[x].degreeName + ";";
            }
            degreeNames = degreeNames + s.preferences[s.preferences.Count - 1].degreeName;
            f.WriteLine(s.name + "," + s.age + "," + s.fscMarks + "," + s.ecatMarks + "," + degreeNames);
            f.Flush();
            f.Close();
        }

        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    int age = int.Parse(splittedRecord[1]);
                    double fscMarks = double.Parse(splittedRecord[2]);
                    double ecatMarks = double.Parse(splittedRecord[3]);
                    string[] splittedRecordForPreference = splittedRecord[4].Split(';');
                    List<degreeProgram> preferences = new List<degreeProgram>();

                    for (int x = 0; x < splittedRecordForPreference.Length; x++)
                    {
                        degreeProgram d = degreeProgramDL.isDegreeExists(splittedRecordForPreference[x]);
                        if (d != null)
                        {
                            if (!(preferences.Contains(d)))
                            {
                                preferences.Add(d);
                            }
                        }
                    }
                    student s = new student(name, age, fscMarks, ecatMarks, preferences);
                    student.Add(s);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
