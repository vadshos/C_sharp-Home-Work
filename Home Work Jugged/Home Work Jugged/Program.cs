using System;

namespace Home_Work_Jugged
{
    class Program
    {
        static void FillRandJugged(int[][] jugged, int left = 1, int rigth = 100)
        {
            Random rand = new Random();
            for (int i = 0; i < jugged.Length; ++i)
            {
                for (int j = 0; j < jugged[i].Length; j++)
                {
                    jugged[i][j] = rand.Next(left, rigth + 1);
                }
            }
        }
        static void PrintJugged(int[][] jugged)
        {
            foreach (var ArrArr in jugged)
            {
                foreach (var item in ArrArr)
                {
                    Console.Write($"{item,-5}");
                }
                Console.WriteLine();
            }
        }
        static void RemoveRow(ref int[][] jugged,int indexRow)
        {
            indexRow -= 1;
            int[][] tempJugged = new int[jugged.Length-1][];
            Array.Copy(jugged, tempJugged, indexRow);
            Array.Copy(jugged, indexRow+1, tempJugged,indexRow, jugged.Length - (indexRow + 1));
            Array.Resize(ref jugged, tempJugged.Length);
            Array.Copy(tempJugged,jugged,tempJugged.Length);
        }
        
        static void cyclicShiftDown(int[][] jugged,int countShift)
        {
            for (int i = 1, j = 0;  i<=countShift&& i < jugged.Length; ++i,++j)
            {
                 var tmp = jugged[i];
                    jugged[i] = jugged[j];
                    jugged[j] = tmp;
               
            }
        }
        static void cyclicShiftUp(int[][] jugged, int countShift)
        {
            int count = 0;
            for (int i = jugged.Length-2, j = jugged.Length-1; i <= countShift && i >= 0&& count != countShift; --i, --j,++countShift)
            {
                var tmp = jugged[i];
                jugged[i] = jugged[j];
                jugged[j] = tmp;

            }
        }
        static void addNewElementInAllRow(ref int [][] jugged,int element = 0)
        {
            for (int i = 0; i < jugged.Length; ++i)
            {
                Array.Resize(ref jugged[i], jugged[i].Length + 1);
                jugged[i][jugged[i].Length - 1] = element;
            }
        }
        static void Main(string[] args)
        {
            int[][] jug = new int[5][] {
                 new int[5],
                new int[2],
                new int[8],
                new int[3],
                new int[7]


            };
            FillRandJugged(jug);
            PrintJugged(jug);
            RemoveRow(ref jug, 2);
            Console.WriteLine();
            addNewElementInAllRow(ref jug, 3);
            PrintJugged(jug);
            Console.WriteLine();
            cyclicShiftDown(jug, 5);
            cyclicShiftUp(jug, 5);
            PrintJugged(jug);

        }
    }
}
