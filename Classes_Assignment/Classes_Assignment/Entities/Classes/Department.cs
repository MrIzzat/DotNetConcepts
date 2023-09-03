using Classes_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Assignment
{
    public class Department : IDepartment
    {
       
         List<Teacher> Teachers { get; set; }
         List<Subject> Subjects { get; set; }
         string DepartmentName { get; set; }
        
    }
}
