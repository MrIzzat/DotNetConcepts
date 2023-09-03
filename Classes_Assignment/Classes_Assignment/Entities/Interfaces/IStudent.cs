using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Assignment
{
    public interface IStudent 
    {
        List<Grade> Grades { set; get; }
        double getAverage();
    }
}
