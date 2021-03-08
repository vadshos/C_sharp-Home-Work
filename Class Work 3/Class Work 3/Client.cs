using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Class_Work_3
{
    class Client
    {
        string numberPhone;
        string name;
        public Client(string name,string numberPhone)
        {
            Name = name;
            NumberPhone = numberPhone;
        }
        public string NumberPhone{
            get => numberPhone;

            set
            {
                 if(value[0] == '+'&&value.Length == 13)
                {
                    string number  = value.Remove(0, 1);
                    if (number.All(c => Char.IsDigit(c))){
                        numberPhone = value;
                    }
                }
                else
                {
                    throw new Exception("bad value");

                }
            }
            }
        public string Name
        {
            get => name;
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new Exception("bad value");
                }
            }
        }
        
        public override string ToString()
        {
            return $"Name : {Name,-5} Number : {numberPhone,-5}";
        }
    }
}
