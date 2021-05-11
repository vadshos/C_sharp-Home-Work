using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeC_sharp_07_interfaces
{
    class Basement : IPart 
    {
        public enum TypeBasement {Tape,Prefabricated,Columnar,Continuous,Welded}
        public TypeBasement Type { get; set; }

        public Basement(TypeBasement typeBasement)
        {
            Type = typeBasement;
        }

    }
}
