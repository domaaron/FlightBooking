using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.models
{
    public enum FlightClass { Economy, Business, First};

    [Table("Booking")]
    public class Booking
    {
        private FlightClass _class;
        private readonly List<Baggage> _baggages = new();
        public Booking(Passenger passenger, Flight flight, string seatNumber, FlightClass flightClass)
        {
            Passenger = default!;
            PassengerId = passenger.Id;
            Flight = flight;
            FlightId = flight.Id;
            SeatNumber = seatNumber;
            this._class = flightClass;
            DateOfBooking = DateTime.Now;
            Guid = Guid.NewGuid();
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Booking() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public int Id { get; private set; }
        public Guid Guid { get; private set; }
        public Passenger Passenger { get; set; }
        public virtual int PassengerId { get; private set; }
        public Flight Flight { get; set; }
        public int FlightId { get; set; }
        public string SeatNumber { get; set; }
        public FlightClass FlightClass { get; set; }
        public DateTime DateOfBooking { get; }
        public string PaymentMethod { get; private set; } = default!;
        public IReadOnlyCollection<Baggage> Baggages => _baggages;

        public void AddBaggage(Booking booking, Baggage baggage)
        {
            if (booking != null && baggage != null)
            {
                if (baggage.Weight > 0 && baggage.Weight <= booking.Flight.Airplane.MaxBaggageWeight)
                {
                    _baggages.Add(baggage);
                }
                else
                {
                    throw new Exception("Weight of baggage does not meet the requirements");
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public int CountBaggages()
        {
            return _baggages.Count;
        }
    }
}
