using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_9
{
    class Client
    {
        long _codeClient;
        string _fullName;
        string _address;
        long _phoneNumber;
        public Client(long codeClient,string fullName,string address,long phoneNumber)
        {
            CodeClient = codeClient;
            FullName = fullName;
            Address = address;
            PhoneNumber = phoneNumber;
        }
        public int CountReplacement { get; set; } = 0;
        public long SumReplacement { get; set; }
        public long CodeClient
        {
            get => _codeClient;
            set
            {
                if (value.ToString().Length < 6)
                {
                    _codeClient = value;
                }
                else
                {
                    throw new Exception("Error value code client");
                }
            }
        }
        public string FullName
        {
            get => _fullName;
            set
            {
                if(value.Split(" ").Length == 3)
                {
                    _fullName = value;
                }
                else
                {
                    throw new Exception("Error value full name");
                }
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                {
                    _address = value;
                }
                else
                {
                    throw new Exception("Error value address");
                }
            }
        }
        public long PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if(value.ToString().Length == 12)
                {
                    _phoneNumber = value;
                }
                else
                {
                    throw new Exception("Error value phone number");
                }
            }
        }
    }
}
