using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ums.BL;

namespace ums.DL
{
    class degreeProgramDL
    {
        public static List<degreeProgram> programList = new List<degreeProgram>();
        public static void addIntoDegreeList(degreeProgram d)
        {
            programList.Add(d);
        }

        public static degreeProgram isDegreeExists(string degreeName)
        {
            foreach (degreeProgram d in programList)
            {
                if (d.degreeName == degreeName)
                {
                    return d;
                }
            }
            return null;
        }

        public static void storeintoFile(string path, degreeProgram d)
        {
            StreamWriter f = new StreamWriter(path, true);
            string SubjectNames = "";
            for (int x = 0; x < d.subjects.Count - 1; x++)
            {
                SubjectNames = SubjectNames + d.subjects[x].type + ";";
            }
            SubjectNames = SubjectNames + d.subjects[d.subjects.Count - 1].type;
            f.WriteLine(d.degreeName + "," + d.degreeDuration + "," + d.seats + "," + SubjectNames);
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
                    string degreeName = splittedRecord[0];
                    float degreeDuration = float.Parse(splittedRecord[1]);
                    int seats = int.Parse(splittedRecord[2]);
                    string[] splittedRecordForSubject = splittedRecord[3].Split(';');
                    degreeProgram d = new degreeProgram(degreeName, degreeDuration, seats);
                    for (int x = 0; x < splittedRecordForSubject.Length; x++)
                    {
                        subject s = subjectDL.isSubjectExists(splittedRecordForSubject[x]);
                        if (s != null)
                        {
                            d.AddSubject(s);
                        }
                    }
                    addIntoDegreeList(d);
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
