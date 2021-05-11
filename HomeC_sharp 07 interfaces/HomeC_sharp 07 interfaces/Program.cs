using System;

namespace HomeC_sharp_07_interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IBuilder builder = new BuilderHouse();
            builder.Reset();
            Director director = new Director(builder);
            director.Make();
        }
    }
}
