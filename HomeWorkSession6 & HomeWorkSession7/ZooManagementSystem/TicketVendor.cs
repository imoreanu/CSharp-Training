using static System.Console;
namespace ZooManagementSystem
{
    public class TicketVendor : Worker
    {
        public int AvailableTickets { get; set; }
        public int SoldTickets { get; set; }
        public TicketVendor(string name, int availableTickets, int soldTickets) : base(name)
        {
            AvailableTickets = availableTickets;
            SoldTickets = soldTickets;
        }

        public void SellTickets(int soldTickets)
        {
            if (AvailableTickets > 0)
            {
                AvailableTickets -= soldTickets;
                WriteLine($"\nThere are {AvailableTickets} tickets available.");
            }
            else if (AvailableTickets == 0)
            {
                WriteLine("\nThe tickets were sold out!");
            }
        }
    }
}
