using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightBooking.Application.models;

namespace FlightBooking.models
{
    public class Flight
    {
        public Flight(DateTime departureTime, DateTime arrivalTime, DateTime destinationTime, Airplane airplane, Address departureAddress, Address arrivalAddress)
        {
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            DestinationTime = destinationTime;
            Airplane = airplane;
            DepartureAddress = departureAddress;
            ArrivalAddress = arrivalAddress;
        }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DestinationTime { get; set; }
        public Airplane Airplane { get; set; }
        public Address DepartureAddress { get; set; }
        public Address ArrivalAddress { get; set; }
    }
}
