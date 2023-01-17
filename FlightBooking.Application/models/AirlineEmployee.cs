using FlightBooking.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Application.models
{
    public class AirlineEmployee : Person
    {
        public AirlineEmployee(Person p, Airline airline, string position)
            : base (p.FirstName, p.LastName, p.SSN, p.BirthDate, p.Address, p.Tel, p.Email)
        {
            Airline = airline;
            AirlineId = airline.Name;
            Position = position;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected AirlineEmployee() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public virtual Airline Airline { get; set; }
        public string AirlineId { get; set; } 
        public string Position { get; set; }
    }
}
