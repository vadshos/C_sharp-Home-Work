using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_6_Overload_Indexator
{
    class CoverBook { 
    public CoverBook(string author, string title, int yearOfPublication)
        {
            Author = author;
            Title = title;
            YearOfPublication = yearOfPublication;
        }
        private string _author;
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
                field.ToLower();
                switch (field)
                {
                    case "author":
                        return Author;
                    case "title":
                        return Title;
                    case "year of publication":
                        return YearOfPublication.ToString(); //Parse type int to string !!!
                    default:
                        throw new Exception("Error index ");
                        
                }
            }
        }
        public static explicit operator CoverBook(Book cover)
        {
            return new CoverBook(cover.Author,  cover.Title, cover.YearOfPublication);
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
        public void print()
        {
            Console.WriteLine($"Title : {_title}");
            Console.WriteLine($"Authot : {_author}");
            Console.WriteLine($"Year of publication : {_yearOfPublication}");
        }
    }
}
