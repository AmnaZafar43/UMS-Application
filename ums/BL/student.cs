using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace ums.BL
{
    class student
    {
        public string name;
        public int age;
        public double fscMarks;
        public double ecatMarks;
        public double merit;
        public List<degreeProgram> preferences;
        public List<subject> regSubject;
        public degreeProgram regDegree;


        public student(string name, int age, double fscMarks, double ecatMarks, List<degreeProgram> preferences)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.preferences = preferences;
            regSubject = new List<subject>();

        }

        public void calculateMerit()
        {
            this.merit = (((fscMarks / 1100) * 0.45F) + ((ecatMarks / 400) * 0.55F)) * 100;

        }


        public bool regStudentSubject(subject s)
        {
            int stCH = getCreditHours();
            if (regDegree != null && regDegree.isSubjectExists(s) && stCH + s.creditHours <= 9)
            {
                regSubject.Add(s);
                return true;
            }
            else
            {
                return false;

            }
        }

        public int getCreditHours()
        {
            int count = 0;
            foreach (subject sub in regSubject)
            {
                count = count + sub.creditHours;
            }
            return count;
        }

        public float calculateFee()
        {
            float fee = 0;
            if (regDegree != null)
            {
                foreach (subject sub in regSubject)
                {
                    fee = fee + sub.subjectFees;
                }
            }
            return fee;
        }
    }
}
