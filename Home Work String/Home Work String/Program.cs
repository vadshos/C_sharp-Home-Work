using System;
using System.Linq;


namespace Home_Work_String
{
    class Program
    {
    static void RemoveAllCharFromString(ref string str,params char[] charsToRemove)
        {
            foreach (var c in charsToRemove)
            {
                str = str.Replace(c,'\0');
            }
        }
        static void printJugger(char[][] jug)
        {
            foreach (var arr in jug)
            {
                
                    Console.Write($"{arr[0]} [{arr.Length}]");
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }
        static void CountLetterInString(string str)
        {
            char[] letter = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
            char[][] countLetter = new char[0][];
            int index = 0;
            foreach (var item in letter)
            {
             int count =  str.Count((e)=>e.Equals(item));
                if(count > 0)
                {
                    Array.Resize(ref countLetter,countLetter.Length+1);
                    Array.Resize(ref countLetter[index], count);
                    countLetter[index][0] = item;
                    ++index;
                }
            }
            printJugger(countLetter);
        }
        static void Main(string[] args)
        {
            //Task 2
            string str = "abfacd";
            char[] charToDelete = { 'a', 'f' };
            RemoveAllCharFromString(ref str, charToDelete);
            Console.WriteLine(str);
            //Task 3
            string str2 = "afffdksgkjdosgfjk";
            CountLetterInString(str2);
        }
    }
}
