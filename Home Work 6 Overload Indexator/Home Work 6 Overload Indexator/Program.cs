using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_6_Overload_Indexator
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Shostak V.V.", "324254", "C#", 2014);
            CoverBook cover = new CoverBook("Shostak V.V.",  "C#", 2013);
            cover = (CoverBook)book;
            cover.print();
            cover.YearOfPublication = 2015;
            book = (Book)cover;
            book.print();
            Console.WriteLine(  book["Author"]);
            Console.WriteLine(book["author"]);
            Console.WriteLine(cover["author"]);

            Liblary liblary = new Liblary();
            liblary.addBook(book);
            liblary[0].print();
            Console.ReadKey();
        }
    }
}
