using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeC_sharp_07_interfaces
{
    class Door : IPart
    {
        public enum TypeDoor {Glass ,Iron,Wood,Profile}
        public TypeDoor Type { get; set; }
        public Door(TypeDoor typeDoor)
        {
            Type = typeDoor;
        }

    }
}
