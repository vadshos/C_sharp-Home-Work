using System;

namespace Home_Work_Overload
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector v = new Vector(1,2);
            Vector v2 = new Vector(0, 0);
            Console.WriteLine(v);
            if (v)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
            if (v2)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
            Console.WriteLine(v--);
            Console.WriteLine(++v);
            Console.WriteLine(v.GetHashCode());
            Console.WriteLine(v2.GetHashCode());
            v = 3;
            Console.WriteLine(v);
        }
    }
}
