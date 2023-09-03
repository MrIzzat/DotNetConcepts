using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Assignment
{
    public interface IPerson
    {
        string Name { get; set; }
        DateTime DateOfBirth { get; set; }
        int PersonID { get; set; }
        int getAge();
    }
}
