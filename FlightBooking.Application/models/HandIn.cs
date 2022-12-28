using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.models
{
    public class HandIn
    {
        public HandIn(Passenger passenger, Flight flight)
        {
            Passenger = passenger;
            Flight = flight;
        }
        public Passenger Passenger { get; set; }
        public Flight Flight { get; set; }
    }
}
