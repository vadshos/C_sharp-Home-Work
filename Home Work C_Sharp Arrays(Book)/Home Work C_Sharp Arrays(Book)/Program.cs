using System;
using System.Collections;



namespace Arrays
{
    class Book
    {
        public Book(string author,string cipher,string title,ushort yearOfPublication)
        {
            Author = author;
            Cipher = cipher;
            Title = title;
            YearOfPublication = yearOfPublication;
        }
        private string _author;
        private string _cipher;
        private string _title;
        private ushort _yearOfPublication;
        public string Author
        {
            get => _author;
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _author = value;
                }
            }
        }
        public string Cipher
        {
            get => _cipher;
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _cipher = value;
                }
            }
        }
        public string Title
        {
            get => _title;
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _title = value;
                }
            }
        }
        public ushort YearOfPublication
        {
            get => _yearOfPublication;
            set
            {
                if (value > 0)
                {
                    _yearOfPublication = value;
                }
            }
        }
        public void print()
        {
            Console.WriteLine($"Title : {_title}");
            Console.WriteLine($"Authot : {_author}");
            Console.WriteLine($"Year of publication : {_yearOfPublication}");
            Console.WriteLine($"Cipher : {_cipher}");
        }
    }

    class Liblary
    {
        private Book[] books;
        public Liblary()
        {
            books = new Book[0];
        }
        public void addBook(Book book)
        {
            if(book != null)
            {
                Array.Resize(ref books, books.Length + 1);
                books[books.Length-1] = book;
            }
        }
        public void removeBookByCipher(string cipher)
        {
            Book[] temp = new Book[books.Length -1];
            Array.Copy(books, temp, books.Length);
            int index = Array.FindIndex(books,e=>e.Cipher == cipher);
            if(index != -1)
            {
                Array.Copy(books, temp, index+1);
                Array.Copy(books,index,temp,books.Length-1, books.Length - index-1);
                books = temp;
            }
        }
        public void SortByAuthor()
        {
            Array.Sort(books, (e, e2) => String.Compare(e.Author, e2.Author));
        }
        public void SortByAuthorAndYearPublication()
        {
            SortByAuthor();
            Array.Sort(books, (e, e2) => (new CaseInsensitiveComparer()).Compare(e.YearOfPublication,e2.YearOfPublication));

        }
        public Book SearchByAuthor(string author)
        {
            Book temp =  Array.Find(books, e => e.Author == author);
            if (temp != null)
            {
                return temp;
            }
            else
            {
                return new Book("", "", "", 0);
            }
        }
        public Book SearchByTitle(string title)
        {
            Book temp = Array.Find(books, e => e.Title == title);
            if (temp != null)
            {
            return temp;
            }
            else
            {
                return new Book("","","",0);
            }

        }
        public  void print()
        {
            if (books.Length > 0)
            {
                Console.WriteLine("#########################");
                foreach (var item in books)
                {
                    item.print();
                    Console.WriteLine("#########################");
                }
            }
        }
    }
}
namespace Home_Work_C_Sharp_Arrays_Book_
{
    class Program
    {
        static void Main(string[] args)
        {
            Arrays.Liblary lib = new Arrays.Liblary();
            Arrays.Book b = new Arrays.Book("Shostak", "1234", "C#", 2017);
            lib.addBook(b);
            lib.addBook(new Arrays.Book("ABROS m.m", "0234", "C#", 2018));
            lib.SortByAuthor();
            lib.print();
            Console.WriteLine();
            lib.SortByAuthorAndYearPublication();
            lib.print();
            Arrays.Book book = lib.SearchByAuthor("Shostak");
            book.print();
        }
    }
}
