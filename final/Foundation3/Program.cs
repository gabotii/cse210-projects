using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Address address2 = new Address("456 Elm St", "Othertown", "TX", "USA");
        Address address3 = new Address("789 Sometown St", "Sometown", "FL", "USA");

        Event lecture = new Lecture("Tech Conference", "A conference on the latest in tech", "2024-09-01", "10:00 AM", address1, "Jane Doe", 100);
        Event reception = new Reception("Wedding reception", "Celebrating the wedding of John and Jane", "2024-10-15", "5:00 PM", address2, "rsvp@example.com");
        Event outdoorGathering = new OutdoorGathering("Company Picnic", "Annual company picnic", "2024-08-20", "12:00 PM", address3, "Sunny");

        List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

        foreach (var ev in events)
        {
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine();
        }
    }
}
