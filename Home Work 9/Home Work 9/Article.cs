using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_9
{
    struct Article :IComparable
    {
        public enum TypeProduct
        {
            TypeFirst,
            TypeSecond,
            TypeThird
        }

        uint _codeProduct;
        string _name;
        int _price;
        TypeProduct _type;
         public Article(uint codeProduct,string name = "",int price = 1,TypeProduct type = TypeProduct.TypeFirst)
        {
            _codeProduct = 0;
            _name = "";
            _price = 0;
            _type = 0;
            CodeProduct = codeProduct;
            Name = name;
            Price = price;
            Type = type;

        }
        public uint CodeProduct
        {
            get => _codeProduct;
            set
            {
                if (value.ToString().Length < 6 && value.ToString().Length > 0)
                {
                    _codeProduct = value;
                }
                else
                {
                    throw new Exception("Error value code");
                }

            }

        }
        public string Name
        {
            get => _name;
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Error value name");
                }
            }
        }
        public int Price
        {
            get => _price;
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
                else
                {
                    throw new Exception("Error value price");
                }
            }
        }
        public TypeProduct Type
        {
            get => _type;
            set
            {
                if(Enum.IsDefined(value))
                {
                    _type = value;
                }
                else
                {
                    throw new Exception("Error value type");
                }
            }
        }

        public int CompareTo(object obj)
        {
            if(obj is Article)
            {
                Article temp = (Article)obj;
                return this.CodeProduct.CompareTo(temp.CodeProduct);
            }
            else
            {
                throw new Exception("object is not a Article");
            }
           
            
        }
    }
    class CmpPriceArticle : IComparer<Article>
    {
        public int Compare(Article x, Article y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}
