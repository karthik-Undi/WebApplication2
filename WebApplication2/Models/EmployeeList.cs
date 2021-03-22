using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class EmployeeList
    {
        static List<Employee> empList = null;
        static EmployeeList()
        {
            empList = new List<Employee>(){
            new Employee()
            {
                Name = "karthik",
                Age = 21          
            }
            };
        }
        public void populate(Employee e)
        {
            empList.Add(e);

        }
        public List<Employee> getemp()
        {
            return empList;
        }


    }
}
