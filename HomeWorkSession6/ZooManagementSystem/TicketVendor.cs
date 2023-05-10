using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    public class TicketVendor : Worker
    {
        public int SoldTickets { get; set; }
        public TicketVendor(string name) : base(name)
        {
            SoldTickets = 0;
        }

        public void SellTickets(int NumberOfTickets)
        {
            SoldTickets += NumberOfTickets;
        }
    }
}
