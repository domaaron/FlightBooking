using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightBooking.Application.models;

namespace FlightBooking.models
{
    [Table("Flight")]
    public class Flight
    {
        public Flight(DateTime departureTime, DateTime arrivalTime, DateTime destinationTime, Airplane airplane, Address departureAddress, Address arrivalAddress)
        {
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            DestinationTime = destinationTime;
            Airplane = airplane;
            AirplaneId = airplane.Id;
            DepartureAddress = departureAddress;
            ArrivalAddress = arrivalAddress;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Flight() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public int Id { get; private set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DestinationTime { get; set; }
        public Airplane Airplane { get; set; }
        public int AirplaneId { get; set; }
        public Address DepartureAddress { get; set; }
        public Address ArrivalAddress { get; set; }
    }
}
