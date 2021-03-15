using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_6_Overload_Indexator
{
    class Book
    {
        public Book(string author, string cipher, string title, int yearOfPublication)
        {
            _listCipher = new List<string>();
            Author = author;
            Cipher = cipher;
            Title = title;
            YearOfPublication = yearOfPublication;
        }
        private List<string> _listCipher;
        private string _author;
        private string _cipher;
        private string _title;
        private int _yearOfPublication;
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
        public string this[string field]
        {
            get
            {
               field =  field.ToLower();
                switch (field)
                {
                    case "author":
                        return Author;
                    case "title":
                        return Title;
                    case "chiper":
                        return Cipher;
                    case "year of publication":
                        return YearOfPublication.ToString(); //Parse type int to string !!!
                    default:
                        throw new Exception("Error index ");
                        
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
                    bool  isNotFound = false;
                    if (_listCipher.Count > 0)
                    {
                        var it  = _listCipher.Find(e => value == e);
                        isNotFound = it  == null ? true : false; 
                    }
                    
                    if (!isNotFound)
                    {
                        _cipher = value;
                        _listCipher.Add(_cipher);
                    }
                    else
                    {
                        throw new Exception("A book with such a cipher already exists");
                    }
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
        public int YearOfPublication
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
        public static explicit operator Book(CoverBook cover)
        {
            Random random = new Random();
            int cipher = random.Next(0,100000);
            return new Book(cover.Author, cipher.ToString(), cover.Title, cover.YearOfPublication);
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
            if (book != null)
            {
                Array.Resize(ref books, books.Length + 1);
                books[books.Length - 1] = book;
            }
        }
        public Book this[int index]
        {
            get
            {
                if(index < books.Length)
                {
                    return books[index];
                }
                throw new Exception("Error index");
            }
            set
            {
                if (index < books.Length)
                {
                    if (value != null)
                    {
                        books[index] = value;
                        return;
                    }
                }            
                    throw new Exception("Error index");
            }
        }
        public Book this[string cipher]
        {
            get
            {
                var it = Array.FindIndex(books, e => e.Cipher == cipher);
                if (it != -1)
                {
                    return books[it];
                }
                throw new Exception("Error index");
            }
            set
            {
                var it = Array.FindIndex(books, e => e.Cipher == cipher);
                if (it != -1)
                {
                    if (value != null)
                    {
                        books[it] = value;
                        return;
                    }
                }
                throw new Exception("Error index");
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
                    item.print();
                    Console.WriteLine("#########################");
                }
            }
        }
    }
}
