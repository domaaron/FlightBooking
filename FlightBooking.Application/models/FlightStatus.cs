using FlightBooking.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Application.models
{
    public class FlightStatus : Flight
    {
        public FlightStatus(Flight flight, string status) 
            :base(flight.DepartureTime, flight.ArrivalTime, flight.DestinationTime, flight.Airplane, flight.DepartureAddress, flight.ArrivalAddress, flight.Price)
        {
            Status = status;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected FlightStatus() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public string Status { get; set; }
        public void ChangeStatus(string status)
        {
            Status = status;
        }
    }
}
