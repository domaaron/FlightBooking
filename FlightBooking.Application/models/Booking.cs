using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.models
{
    public enum FlightClass { Economy, PremiumEconomy, Business, First};

    [Table("Booking")]
    public class Booking
    {
        private FlightClass _class;
        public Booking(Flight flight, string seatNumber, FlightClass flightClass, decimal price)
        {
            Passenger = default!;
            Flight = flight;
            FlightId = flight.Id;
            SeatNumber = seatNumber;
            this._class = flightClass;
            DateOfBooking = DateTime.Now;
            Price = price;
            Guid = Guid.NewGuid();
        }

        protected Booking(Booking booking) 
        {
            Id = booking.Id;
            Passenger = booking.Passenger;
            PassengerId = booking.PassengerId;
            Flight = booking.Flight;
            FlightId = booking.FlightId;
            SeatNumber = booking.SeatNumber;
            FlightClass = booking.FlightClass;
            Price = booking.Price;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Booking() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public int Id { get; private set; }
        public Guid Guid { get; private set; }
        public int PassengerId { get; set; }
        public virtual Passenger Passenger { get; set; }
        public virtual Flight Flight { get; set; }
        public int FlightId { get; set; }
        public string SeatNumber { get; set; }
        public FlightClass FlightClass { get; set; }
        public DateTime DateOfBooking { get; }
        public decimal Price { get; set; }
        public string BookingType { get; private set; } = default!;
        protected List<Baggage> _baggages = new();
        public virtual IReadOnlyCollection<Baggage> Baggages => _baggages;

        public void AddBaggage(Baggage baggage)
        {
            if (baggage != null)
            {
                if (baggage.Weight > 0 && baggage.Weight <= this.Flight.Airplane.MaxBaggageWeight)
                {
                    _baggages.Add(baggage);
                }
                else
                {
                    throw new ArgumentException("Weight of baggage does not meet the requirements");
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
