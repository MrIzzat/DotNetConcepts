using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetConcepts
{
    internal class Student : IStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<IGrade> Grades { get; set; }

        public Student(int id, string name, List<IGrade> grades)
        {
            Id = id;
            Name = name;
            Grades = grades;
        }

        public double getAverage()
        {
            double sum = 0;
            foreach(Grade grade in Grades)
            {
                sum += grade.Mark;
            }
            return sum/Grades.Count;
        }
    }
}
