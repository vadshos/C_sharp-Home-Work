using System;

namespace Jugged_FileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[][] jug = new byte[3][];
            for (int i = 0; i < jug.Length; i++)
            {
                jug[i] = new byte[3];
                for (int j = 0; j < jug[i].Length; j++)
                {
                    jug[i][j] = (byte)new Random().Next(9);
                }
            }
            JuggedFileWork.Write("jug.dat", jug);
            foreach (var item in JuggedFileWork.Read("jug.dat"))
            {
                foreach (var elem in item)
                {
                    Console.Write(elem);
                }
                Console.WriteLine();
            }
        }
    }
}
