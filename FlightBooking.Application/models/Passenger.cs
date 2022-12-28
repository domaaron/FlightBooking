using System;
using System.Collections.Generic;
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

        private readonly List<Booking> _bookings = new();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public IReadOnlyList<Booking> Bookings => _bookings;

        public void AddBooking(Booking b)
        {
            _bookings.Add(b);
        }
    }
}
