using System;


//4. Визначити узагальнений метод, що впорядковує одновимірний масив методом бульбашки(чи ін. методом)
//використовуючи для порівняння пари елементів делегат Comparison<T>

//Виконати за допомогою визначеного методу 
//o	Впорядкування масиву рядків за зростанням довжин(як  фактичний параметр можна використати лямбду або метод,
//що відповідає делегату Comparison<T>)
//o Впорядкування масиву Продуктів(чи ін.) за значення певного поля(ціною чи інше)
namespace Delegate
{
    class Product
    {
        public uint price;
        public string name;
        public void Print()
        {
            Console.WriteLine("Name : "+name);
            Console.WriteLine("Price : "+price.ToString());
        }
    }
    class Program
    {

        delegate void ChangeElemPredicate(ref  int elem);
        delegate bool FindAllPredicate(int elem);


        static void ChangeElemArray(int [] arr,ChangeElemPredicate changeElem)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                changeElem(ref arr[i]);
            }
        }
        static int[] FindAll(int [] arr ,FindAllPredicate findAll) 
        {
            int[] temp = new int[0];
            foreach (var item in arr)
            {
                if (findAll(item))
                {
                    Array.Resize(ref temp, temp.Length + 1);
                    temp[temp.Length - 1] = item;
                }
            }
            return temp;
        }
        static void Sort<T>(T[] arr, Comparison<T> comp) {
            Array.Sort<T>(arr, comp);
        }        
        static void Main(string[] args)
        {
            int[] arr = { 3, 5, 7, 84, 346, 457 };
            ChangeElemArray(arr, (ref int e) => e++);
            ChangeElemArray(arr, (ref int e) => e = e - 2);

            foreach (var item in arr)
            {
                Console.Write(item+" ");
            }
            int[] newArr = FindAll(arr, e => e % 2 == 0);
            Console.WriteLine();
            foreach (var item in newArr)
            {
                Console.Write(item + " ");
            }
            string[] strArr = { "short", "long", "middle" };           
            Sort<string>(strArr, (e, e2) => e.Length.CompareTo(e2.Length));
            Console.WriteLine();
            foreach (var item in strArr)
            {
                Console.Write(item+" ");
            }
            Product[] products = { new Product { name = "First", price = 455 }, new Product { name = "Second", price = 234 },new Product {name = "Third",price = 5345 } };
            Sort<Product>(products, (e, e2) => e.price.CompareTo(e2.price));
            foreach (var item in products)
            {
                item.Print();
                Console.WriteLine();
            }
        }
    }
}
