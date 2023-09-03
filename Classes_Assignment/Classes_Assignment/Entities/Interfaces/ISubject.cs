using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Assignment
{
    public interface ISubject
    {

        string Name { get; set; }
        string SubjectID { get; set; }
        Department Department { get; set; }
    }
}
