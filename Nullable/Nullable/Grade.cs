using System;
using System.Collections.Generic;
using System.Text;

namespace Nullable
{
    class Grade
    {
        private ushort? _grade;
        private DateTime _date;
        public Grade(ushort? grade,DateTime date)
        {
            Mark = grade;
            Date = date;
        }
        public ushort? Mark
        {
            get => _grade;
            set
            {
                if(value == null)
                {
                    _grade = value;
                }
                else if(value > 0 && value < 13)
                {
                    _grade = value;

                }
                else
                {
                    throw new Exception("bad grade");
                }

            }
        }
        public DateTime Date
        {
            get => _date;
            set
            {
                if(value >= DateTime.Today)
                {
                    _date = value;
                }
                else
                {
                    throw new Exception("Bad Date");
                }

            }
        }
        public override string ToString()
        {
            return $"Grade : {Mark,3} | date {Date.ToShortDateString()}";
        }
    }
}
