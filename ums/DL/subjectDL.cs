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
    class subjectDL
    {
        public static List<subject> subjectList = new List<subject>();

        public static void addSubjectIntoList(subject s)
        {
            subjectList.Add(s);
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
                    string code = splittedRecord[0];
                    string type = splittedRecord[1];
                    int creditHours = int.Parse(splittedRecord[2]);
                    int subjectFees = int.Parse(splittedRecord[3]);
                    subject s = new subject(code, type, creditHours, subjectFees);
                    addSubjectIntoList(s);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void storeintoFile(string path, subject s)
        {
            StreamWriter f = new StreamWriter(path, true);
            f.WriteLine(s.code + "," + s.type + "," + s.creditHours + "," + s.subjectFees);
            f.Flush();
            f.Close();
        }
        public static subject isSubjectExists(string type)
        {
            foreach (subject s in subjectList)
            {
                if (s.type == type)
                {
                    return s;
                }
            }
            return null;
        }
    }
}