using FlightBooking.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Application.models
{
    public class AirlineEmployee : Passenger
    {
        public AirlineEmployee(Passenger passenger, Airline airline, string position)
            : base (passenger.FirstName, passenger.LastName, passenger.SSN, passenger.BirthDate, passenger.Address, passenger.Tel, passenger.Email)
        {
            Position = position;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected AirlineEmployee() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public string Position { get; set; }
    }
}
