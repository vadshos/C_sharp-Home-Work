using System;
using System.Collections.Generic;

namespace Home_C_sharp_12
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiMap<int, string> map = new MultiMap<int, string>();
            map.Add(new KeyValuePair<int, string>(3, "lol"));
            foreach (var item in map)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
