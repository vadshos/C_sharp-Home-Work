using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Work_3
{
    class Event
    {
         public Event(Client client,string name,string venue,DateTime timeOfHolding,uint countPerson)
        {
            Name = name;
            Venue = venue;
            TimeOfHolding = timeOfHolding;
            Client = client;
            Id = ++Counter;
            CountPerson = countPerson;
        }
        public enum TypeTransferTimeOfHolding
        {
            DAY,
            WEAK
        };
        string _name;
        string _venue;
        uint _countPerson;
        DateTime _timeOfHoldind;
        static ushort _counter = 0;
        ushort _id;
        Client _client;
        public uint CountPerson
        {
            get => _countPerson;
            set => _countPerson = value > 0 ? value : throw new Exception("bad value countPerson");
        }
        public void TransferTimeOfHolding(ushort count,TypeTransferTimeOfHolding typeTransfer)
        {
            if (count > 0)
            {
                if (typeTransfer == TypeTransferTimeOfHolding.DAY)
                {
                    TimeOfHolding = TimeOfHolding.AddDays(count);
                }
                if (typeTransfer == TypeTransferTimeOfHolding.WEAK)
                {
                    TimeOfHolding = TimeOfHolding.AddDays(count*7);
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
                    throw new Exception($"bad value name");
                }
            }
        }
        public string Venue
        {
            get => _venue;
            set
            {
                if (!String.IsNullOrEmpty(value))
                    _venue = value;
                else
                    throw new Exception("bad value venue");
            }
        }
        public DateTime TimeOfHolding
        {
            get => _timeOfHoldind;
            set
            {
                if (DateTime.Today < value)
                {
                    _timeOfHoldind = value;
                }
                else
                {
                    throw new Exception("bad value timeOfHolding");
                }
            }
        }
        public Client Client {

            get => _client;

            set
            {
                if(value != null)
                {
                    _client = value;
                }
            }
        }
        public ushort Counter
        {
            get => _counter;
            private set => _counter = value;

        }
        public ushort Id
        {
            get => _id;
            private set => _id = value;
        }
        public override string ToString()
        {
            return $" Id : {Id}\n Name events : {Name} \n Client : {Client}\n Count person : {CountPerson}\n Venue : {Venue}\n Time of holding : {TimeOfHolding.ToShortTimeString()}\n Date : {TimeOfHolding.ToShortDateString()}";
        }
    }
}
