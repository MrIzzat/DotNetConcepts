using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Assignment
{
    public class Subject : ISubject
    {
 
        public string Name { get ; set ; }
        public string SubjectID { get ; set ; }
        public Department Department { get; set; }
    }
}
