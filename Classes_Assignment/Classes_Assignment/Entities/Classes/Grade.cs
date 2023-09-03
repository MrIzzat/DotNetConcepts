using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Assignment
{
    public class Grade : Models.IGrade
    {
     
        public double Amount { get; set; }
        public Student Student { get; set; }

    }
}
