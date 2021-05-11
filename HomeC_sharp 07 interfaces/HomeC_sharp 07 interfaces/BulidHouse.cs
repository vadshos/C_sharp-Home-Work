using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeC_sharp_07_interfaces
{
    class BuilderHouse : IBuilder
    {
        protected House house;
        public void InstallBasement(Basement.TypeBasement typeBasement)
        {
            if (house.Parts.Count == 0)
            {
                Console.WriteLine("Install Basement");
                house.AddPart(new Basement(typeBasement));
            }
        }

        public void InstallDoor(Door.TypeDoor typeDoor)
        {
            if (house.Parts.Find(e => e as Wall != null) != null)
            {
                Console.WriteLine("Install Door");
                house.AddPart(new Door(typeDoor));
            }
        }

        public void InstallRoof()
        {
            if (house.Parts.Find(e => e as Wall != null) != null)
            {
                Console.WriteLine("Install Roof");
                house.AddPart(new Roof { });
            }
        }

        public void InstallWall()
        {
          
           if(house.Parts.Find(e => e as Basement != null) != null)     {
                Console.WriteLine("Install Wall");
                house.AddPart(new Wall { });
           }
        }

        public void InstallWindow()
        {
            if (house.Parts.Find(e => e as Wall != null) != null)
            {
                Console.WriteLine("Inlall Window");
                house.AddPart(new Window { });
            }
        }

        public void Reset()
        {
            house = new House(new List<IPart>());
        }

    }
}
