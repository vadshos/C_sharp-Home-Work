using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeC_sharp_07_interfaces
{
    interface IBuilder
    {
        void Reset();
        void InstallBasement(Basement.TypeBasement typeBasement);
        void InstallWall();
        void InstallRoof();
        void InstallWindow();
        void InstallDoor(Door.TypeDoor typeDoor);
    }
}
