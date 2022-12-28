using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.models
{
    public class Booking
    {
        private readonly List<Baggage> _baggages = new();
        public Booking(Passenger passenger, Flight flight, string seatNumber, FlightClass flightClass)
        {
            Passenger = passenger;
            Flight = flight;
            SeatNumber = seatNumber;
            FlightClass = flightClass;
        }
        public Passenger Passenger { get; set; }
        public Flight Flight { get; set; }
        public string SeatNumber { get; set; }
        public FlightClass FlightClass { get; set; }
        public IReadOnlyList<Baggage> Baggages => _baggages;

        public void AddBaggage(Baggage b)
        {
            _baggages.Add(b);
        }
    }
}
