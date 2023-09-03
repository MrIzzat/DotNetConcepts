using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Assignment.Models
{
    public interface IGrade
    {

        double Amount { get; set; }
        Student Student { get; set; }
    }
}
