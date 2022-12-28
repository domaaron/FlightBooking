using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.models
{
    [Table("HandIn")]
    public class HandIn
    {
        public HandIn(Passenger passenger, Flight flight)
        {
            Passenger = passenger;
            PassengerId = passenger.Id;
            Flight = flight;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected HandIn() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public int Id { get; private set; }
        public Passenger Passenger { get; set; }
        public int PassengerId { get; set; }
        public Flight Flight { get; set; }
    }
}
