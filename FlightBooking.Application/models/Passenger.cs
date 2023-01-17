using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.DataSets;
using FlightBooking.Application.models;

namespace FlightBooking.models
{ 
    public class Passenger : Person
    {
        public Passenger(Person p) 
            : base (p.FirstName, p.LastName, p.SSN, p.BirthDate, p.Address, p.Tel, p.Email) { }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Passenger() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        protected List<Booking> _bookings = new();
        public virtual IReadOnlyCollection<Booking> Bookings => _bookings;
        public void PlaceBooking(Booking b)
        {
            if (b != null)
            {
                if (b.DateOfBooking < b.Flight.ArrivalTime)
                {
                    if (b.Flight.IsActive == true)
                        _bookings.Add(b);
                }
                else
                {
                    throw new Exception("Booking of the selected flight is not possible anymore");
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void CancelBooking(Booking b)
        {
            if (b != null)
            {
                _bookings.Remove(b);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public int CountBookings()
        {
            return _bookings.Count;
        }

        public void ConfirmBooking(Booking b, DateTime paymentDate, string paymentMethod)
        {
            if (b is ConfirmedBooking)
            {
                return;
            }

            var confirmedBooking = new ConfirmedBooking(b, paymentDate, paymentMethod);
            _bookings.Remove(b);
            _bookings.Add(confirmedBooking);
        }
    }
}
