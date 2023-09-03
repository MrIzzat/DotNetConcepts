using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Assignment
{
    public abstract class Person : IPerson
    {


        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PersonID { get; set; }

        public int getAge()
        {
            int days = ((DateTime.Today) - DateOfBirth).Days;
            days++;
            int years = (int)(days / 365.25);

            return years;
        }

    }
}
