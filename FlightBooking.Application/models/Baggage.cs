using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.models
{
    public class Baggage
    {
        public Baggage(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name { get; set; }
        public double Weight { get; set; }
    }
}
