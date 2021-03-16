using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_7
{
    class Employee
    {
        private string _name;
        private string _surname;
        readonly uint _id;
        static uint _count;
        private ushort _salary;
        public Employee(string name,string surname,ushort salary)
        {
            Name = name;
            Surname = surname;
            Salary = salary;
            _id = ++_count;
        }
        bool checkedNameAndSurname(string checkedValue,string str)
        {
            if (!String.IsNullOrEmpty(checkedValue))
            {
                if (checkedValue.All(e => Char.IsLetter(e)))
                {
                    return true;
                }
                throw new NameAndSurnameExepcion(str + " have divisor " + checkedValue);

            }
            throw new NameAndSurnameExepcion(str + " Null Or Empty " + checkedValue);
        }

        void ReinputSalary()
        {
            float procentUpSalary;
            float.TryParse(Console.ReadLine(),out procentUpSalary);
            SalaryIncrease(procentUpSalary);
        }
        public void SalaryIncrease(float procentUpSalary)
        {
            try
            {
                checked
                {
                    float newSalary = Salary+Salary * procentUpSalary;
                    _salary = (ushort)newSalary;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Salary can't be more 65035");
                ReinputSalary();
            }
        }
        public ushort Salary
        {
            get => _salary;
            set
            {
                _salary = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                try
                {
                    checkedNameAndSurname(value,"Name");
                    _name = value;
                }
                catch (NameAndSurnameExepcion ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                try
                {
                    checkedNameAndSurname(value, "Surname");
                    _surname = value;
                }
                catch (NameAndSurnameExepcion ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public uint Id
        {
            get => _id;
        }
        public override string ToString()
        {
            return $"Id : {Id} | Name : {Name} | Surname {Surname} | Salary : {Salary}";
        }
    }
}
