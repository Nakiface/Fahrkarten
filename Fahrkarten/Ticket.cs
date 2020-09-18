using System;

namespace Fahrkarten
{
    public class Ticket
    {
        public String Name {get; set; }
        public decimal Price { get; set; }
        public Ticket(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
