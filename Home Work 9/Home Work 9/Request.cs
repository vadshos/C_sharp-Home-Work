using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_9
{
    //    код замовлення;
    //    клієнт(посилання на об'єкт класу Client);
    //    дата замовлення (структура DateTime);
    //    перелік замовлених товарів(масив чи список структур RequestItem );
    //    сума замовлення(реалізувати read-only властивістю, значення якої обчислюється в get-і).

    class Request : ICloneable
    {
        uint _codeRequest;
        Client _client;
        DateTime _date;
        List<RequestItem> _requestItems = new List<RequestItem>();
        public Request(){}
        public Request(uint codeRequest, Client client,DateTime date)
        {
            CodeRequest = codeRequest;
            Customer = client;
            Date = date;
        }
        public uint CodeRequest
        {
            get => _codeRequest;
            set
            {
                if (value.ToString().Length < 6)
                {
                    _codeRequest = value;
                }
                else
                {
                    throw new Exception("Error value code client");
                }
            }
        }
        public void AddRequestItem(RequestItem item)
        {

            _requestItems.Add(item);
            unchecked
            {
                Customer.CountReplacement = Customer.CountReplacement+1;
                Customer.SumReplacement += item.Article.Price;
            }
        }

        public object Clone()
        {
            return new Request(this.CodeRequest,this.Customer,this.Date);
        }

        public Client Customer
        {
            get => _client;
            set
            {
                if(value != null)
                {
                    _client = value;
                }
                else
                {
                    throw new Exception("Error value customer");
                }
            }
        }
        public DateTime Date
        {
            get => _date;
            set
            {
                if(value <= DateTime.Now)
                {
                    _date = value;
                }else
                {
                    throw new Exception("Error value date");
                }
            }
        }
        public int SumRequest
        {
            get
            {
                return   _requestItems.Sum(e => e.Article.Price);
            }
            
        }
        public void Fill()
        {
            string[] fullName = { "Ivanov ivan Ivanovych", "Petrov Petro Petrovych" };
            this.CodeRequest = (uint)new Random().Next(1,1100);
        }


    }
}
