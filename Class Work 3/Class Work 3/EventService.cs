using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Work_3
{
    class EventService
    {
        List<Event> _events;
        public EventService()
        {
            _events = new List<Event>();
        }
        public void AddEvents(Event @event)
        {
            _events.Add(@event);
        }
        public void Clear()
        {
            _events.Clear();
        }
        public void RemoveEvent(DateTime dateTime,string venue)
        {
            int index = _events.FindIndex(e =>
            {
                if (e.Venue.CompareTo(venue) == 0 && e.TimeOfHolding == dateTime)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
            if(index >= 0)
            _events.RemoveAt(index);
        }
        public void Print()
        {
            foreach (var item in _events)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }
        public void findAndEventForSomeDate(DateTime date)
        {
            var list = _events.FindAll(e => e.TimeOfHolding == date);
            printListEvenst(list);

        }
        public void findAndPrintPrintEventForSomeClient(Client client)
        {
           var list  = _events.FindAll(e => e.Client.Name.CompareTo(client.Name) == 0 && e.Client.NumberPhone.CompareTo(client.NumberPhone) == 0);
            printListEvenst(list);

        }
        public void findAndPrintEventForDateRange(DateTime dateLeft, DateTime dateRigth)
        {
            var list = _events.FindAll(e => e.TimeOfHolding > dateLeft&&e.TimeOfHolding<dateRigth);
            printListEvenst(list);
        }


        public void printListEvenst (List<Event> events)
        {
            foreach (var item in events)
            {
                Console.WriteLine($"{item}\n");
            }
        }
    }
}
