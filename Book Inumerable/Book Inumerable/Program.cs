﻿using System;
using System.Collections;



namespace Arrays
{
    class Book
    {
        public Book(string author, string cipher, string title, ushort yearOfPublication)
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
        public void Print()
        {
            Console.WriteLine($"Title : {_title}");
            Console.WriteLine($"Authot : {_author}");
            Console.WriteLine($"Year of publication : {_yearOfPublication}");
            Console.WriteLine($"Cipher : {_cipher}");
        }
    }

    class Liblary : IEnumerable
    {
        private Book[] books;
        public Liblary()
        {
            books = new Book[0];
        }
        public void addBook(Book book)
        {
            if (book != null)
            {
                Array.Resize(ref books, books.Length + 1);
                books[books.Length - 1] = book;
            }
        }
        public void removeBookByCipher(string cipher)
        {
            int index = Array.FindIndex(books, e => e.Cipher == cipher);
            if (index != -1)
            {
                Book[] temp = new Book[books.Length - 1];
                Array.Copy(books, temp, index);

                Array.Copy(books, index, temp, books.Length - 1, books.Length - index - 1);
                books = new Book[temp.Length];
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
            Array.Sort(books, (e, e2) => (new CaseInsensitiveComparer()).Compare(e.YearOfPublication, e2.YearOfPublication));

        }
        public Book SearchByAuthor(string author)
        {
            Book temp = Array.Find(books, e => e.Author == author);
            if (temp != null)
            {
                return temp;
            }
            else
            {
                throw new Exception("didn't find book by author " + author);

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
                throw new Exception("didn't find book by title " + title);

            }

        }
        public void print()
        {
            if (books.Length > 0)
            {
                Console.WriteLine("#########################");
                foreach (var item in books)
                {
                    item.Print();
                    Console.WriteLine("#########################");
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return books.GetEnumerator();
        }
        public IEnumerable ReverseGetEnumerator()
        {
            for (int i = books.Length-1; i >= 0; i--)
            {
                yield return books[i];
            }
        }
        public IEnumerable GetEnumeratorByAuthor(string author)
        {
            return (IEnumerable)(Array.FindAll<Book>(books, e => e.Author == author));
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
            
            Console.WriteLine("\nGetEnumerator\n");
            foreach (Arrays.Book item in lib)
            {
                item.Print();
                Console.WriteLine();

            }
            Console.WriteLine("\nReverseGetEnumerato\n");
            foreach (Arrays.Book item in ((IEnumerable)lib.ReverseGetEnumerator()))
            {
                item.Print();
                Console.WriteLine();

            }
            Console.WriteLine("\nGetEnumeratorByAuthor\n");
            foreach (Arrays.Book item in (IEnumerable)lib.GetEnumeratorByAuthor("Shostak"))
            {
                item.Print();
                Console.WriteLine();
            }
        }
    }
}

