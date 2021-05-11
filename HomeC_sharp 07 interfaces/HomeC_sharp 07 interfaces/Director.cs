using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeC_sharp_07_interfaces
{
    class Director
    {
        IBuilder builder;
        public Director(IBuilder builder)
        {
            this.builder = builder;
        }
        public void ChangeBuilder(IBuilder builder)
        {
            this.builder = builder;
        }
        public void Draw()
        {
            int width = 15;

            int heigth = 30;
            int middle = width % 2 == 0 ? (width / 2) - 1 : width / 2;
            int heightRoof = middle + 1;

            for (int i = 0; i < heightRoof; i++)
            {
                for (int j = middle - i - 1; j >= 0; j--)
                {
                   Console.Write(".");
                }
                if (i == 0)
                {
                   Console.Write("**");
                   Console.WriteLine();
                    continue;
                }
                else
                {
                   Console.Write("/");
                    for (int k = 0; k < 2 * i; k++)
                    {
                       Console.Write(".");
                    }
                }
               Console.Write("\\");
               Console.WriteLine();
            }

            heigth = middle;
            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width+1; j++)
                {
                    if(i == 0 || i == heigth-1)
                    {
                        Console.Write("-");
                    }else
                    {
                        if(j == 0 || j == width)
                        {
                            Console.Write("|");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    

        public void Make()
        {
            builder.InstallBasement(Basement.TypeBasement.Prefabricated);
            builder.InstallWall();
            builder.InstallRoof();
            builder.InstallDoor(Door.TypeDoor.Glass);
            builder.InstallWindow();
            Draw();

        }
    }
}
