using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Nullable
{
    class Student
    {
        public Student(string fullName)
        {
            FullName = fullName;
            _grades = new List<Grade>();
        }
        string _fullName;
        List<Grade> _grades;
        private int count = 0;
        public string FullName
        {
            get => _fullName;
            set
            {
                string[] arr = value.Split(" ");
                if(arr.Length == 3)
                {
                    _fullName = value;
                }
                else
                {
                    throw new Exception("bad full name");
                }
            }
        }
        public void AddGrade(Grade grade)
        {
            _grades.Add(grade);
            count++;
        }
        public void EditGradeByDate(DateTime date,ushort grade)
        {
           var it = _grades.Find((e)=>e.Date == date);
            if(it != null)
            {
                it.Mark = grade;
            }
        }
        public void RemoveGrade(int number)
        {
            bool isRemove  = EditGradeByNumber(number, null);
            if (isRemove)
                count--; 
        }
        public bool EditGradeByNumber(int number, ushort? grade)
        {
            if (number < _grades.Count)
            {
                _grades[number].Mark = grade;
                return true;
            }
            
                return false;
        }
        public int AvaregeGrade()
        {
            return (_grades.Sum(x => Convert.ToInt32(x.Mark))/count);
        }
        public override string ToString()
        {
            string data = FullName;
            data += "\n----------------------------";
            foreach (var item in _grades)
            {
                if(item.Mark != null)
                data += $"\n{item.ToString()}";
            }
            return data;
        }
    }
}
