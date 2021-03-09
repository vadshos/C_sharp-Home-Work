using System;
using Class_Work_3;

namespace Class_Work_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("Petro", "+380681616379");
            Event event1 = new Event(client, "Birthday", "Restorans Afin", new DateTime(2021, 8, 9,18,0,0), 60);
            Event event2  = new Event(client, "Birthday", "Restorans Afina", new DateTime(2021, 9, 9,13,8,0), 60);
            EventService eventService = new EventService();
            eventService.AddEvents(event2);
            eventService.AddEvents(event1);
            eventService.Print();
            eventService.RemoveEvent(event1.TimeOfHolding,event1.Venue);
            eventService.Print();
            eventService.findAndEventForSomeDate(event2.TimeOfHolding);
        }
    }
}
