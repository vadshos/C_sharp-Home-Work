using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Department departmentIT = new Department();
            Employee employee = new Employee("Vadym", "Shostak", 1000);
            departmentIT.AddEmployee(employee);
            Console.WriteLine(departmentIT);
            employee.SalaryIncrease(100.5f);
            Console.WriteLine(departmentIT);


            Console.ReadKey();
        }
    }
}
