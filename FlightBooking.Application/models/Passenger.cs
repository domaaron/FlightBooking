using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.DataSets;
using FlightBooking.Application.models;

namespace FlightBooking.models
{
    public class Passenger
    {
        public Passenger(string firstName, string lastName, string sSN, DateTime birthDate, Address address, string tel, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            SSN = sSN;
            BirthDate = birthDate;
            Address = address;
            Tel = tel;
            Email = email;
        }
        private readonly List<Booking> _bookings => new();
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
