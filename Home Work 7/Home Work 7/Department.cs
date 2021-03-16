using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_7
{
    class Department
    {
        private List<Employee> employees = new List<Employee>();
        public void AddEmployee(Employee employee)
        {
            if (employee != null)
                employees.Add(employee);
            else
                throw new Exception("You can't add null");
        }
        private void ReinputIdForDelete()
        {
            Console.Write("Enter correct id for remove : ");
            uint id;
            uint.TryParse(Console.ReadLine(), out id);
            RemoveEmployee(id);
        }
        public void RemoveEmployee(uint id)
        {
            
                if (employees.Count == 0)
                {
                   throw new DepartmentExcepcionOutOfRange("Department don't have some employer");
                }
            
            int index  = employees.FindIndex(e => e.Id == id);
            if (index != -1)
            {
                employees.RemoveAt(index);
                return;
            }
            try
            {
                throw new DepartmentExcepcionOutOfRange("Department don't have employer with this id");
            }
            catch (DepartmentExcepcionOutOfRange ex)
            {
                Console.WriteLine(ex.Message);
                ReinputIdForDelete();
            }
        }
        public override string ToString()
        {
            string returnValue = "";
            foreach (var item in employees)
            {
                returnValue += item + "\t";
            }
            return returnValue;
        }
    }
}
