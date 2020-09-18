using System.Collections.Generic;
using System.Linq;

namespace Fahrkarten
{
    public class TicketTypes
    {
        public List<Ticket> ticketList { get; set; }

        public TicketTypes()
        {
            this.ticketList = CreateTicketList();
        }

        public List<string> CreateListForComboBox()
        {
            List<string> result = new List<string>();
            foreach (var ticket in ticketList)
            {
                result.Add($"{ticket.Name} | Kosten: {ticket.Price}€");
            }
            return result;
        }

        public Ticket FindTicketFromText(string text)
        {
            var ticketName = text.Split(" | ").FirstOrDefault();
            var ticket = ticketList.Where(x => x.Name == ticketName).FirstOrDefault();
            return ticket;
        }

        private List<Ticket> CreateTicketList()
        {
            return new List<Ticket>()
            {
                new Ticket("Fahrkarte AB", 1.80m),
                new Ticket("Fahrkarte BC", 2.30m),
                new Ticket("Fahrkarte ABC", 2.60m)
            };
        }
    }
}
