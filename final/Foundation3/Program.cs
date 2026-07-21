
public class Program
{
    public static void Main()
    {
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Oak Ave", "London", "Greater London", "UK");
        Address address3 = new Address("789 Pine Rd", "Sydney", "NSW", "Australia");

        Lecture lecture = new Lecture("AI Revolution", "Exploring artificial intelligence", "2026-07-20", "10:00 AM", address1, "Dr. Smith", 150);
        Reception reception = new Reception("Networking Gala", "Annual networking event", "2026-07-21", "7:00 PM", address2, "rsvp@events.com");
        OutdoorGathering outdoor = new OutdoorGathering("Summer Festival", "Outdoor music festival", "2026-07-22", "12:00 PM", address3, "Sunny, 75°F");

        Event[] events = { lecture, reception, outdoor };

        foreach (Event ev in events)
        {
            System.Console.WriteLine("=== STANDARD DETAILS ===");
            System.Console.WriteLine(ev.GetStandardDetails());
            System.Console.WriteLine("\n=== FULL DETAILS ===");
            System.Console.WriteLine(ev.GetFullDetails());
            System.Console.WriteLine("\n=== SHORT DESCRIPTION ===");
            System.Console.WriteLine(ev.GetShortDescription());
            System.Console.WriteLine("\n----------------------------\n");
        }
    }
}