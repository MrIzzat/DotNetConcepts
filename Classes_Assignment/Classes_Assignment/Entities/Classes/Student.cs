using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Assignment
{
    public class Student : Person, IStudent
    { 
        public List<Grade> Grades { set; get; }

        public double getAverage()
        {
            double average = 0;
            for (int i = 0; i < Grades.Count; i++)
            {
                average += Grades[i].Amount;
            }

            average = average / Grades.Count;

            return average;
        }

    }
}