using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_7
{
    class NameAndSurnameExepcion : ArgumentException
    {
        public NameAndSurnameExepcion(string message) : base(message)
        {
        }
    }
}
