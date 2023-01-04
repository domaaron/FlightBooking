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
    public record Address(string State, string City);

    [Table("Passenger")]
    public class Passenger
    {
        public Passenger(string firstName, string lastName, string ssn, DateTime birthDate, Address address, string tel, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            SSN = ssn;
            BirthDate = birthDate;
            Address = address;
            Tel = tel;
            Email = email;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Passenger() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public int Id { get; private set; }
        [MaxLength(64)]
        public string FirstName { get; set; }
        [MaxLength(64)]
        public string LastName { get; set; }
        [MaxLength(10)]
        public string SSN { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public string Tel { get; set; }
        [MaxLength(64)]
        public string Email { get; set; }
        protected List<Booking> _bookings = new();
        public virtual IReadOnlyCollection<Booking> Bookings => _bookings;
        public string PassengerType { get; private set; } = default!;
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
    }
}
