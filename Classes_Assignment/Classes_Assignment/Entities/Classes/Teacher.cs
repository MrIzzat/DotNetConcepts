using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Assignment
{
    public class Teacher : Person, ITeacher
    {
        public  List<Subject> Subjects { get; set; }
    }
}
