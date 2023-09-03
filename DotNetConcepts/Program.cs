using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetConcepts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IGrade> grades = new List<IGrade>(){

                new Grade(90, "Math"),
                new Grade(90, "Math"),
                new Grade(101,"Arabic"),
                new Grade(99,"English")
            };
            int Id = 20;
            string Name = "Izzat";
            
            IStudent student = new Student(Id,Name,grades);//Grades are injected here

            Console.WriteLine(student.getAverage());
        }
    }
}
