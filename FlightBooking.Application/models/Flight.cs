﻿using FlightBooking.Application.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.models
{
    [Table("Flight")]
    public class Flight
    {
        public Flight(DateTime departureTime, DateTime arrivalTime, DateTime destinationTime, Airplane airplane, Airline airline, Address departureAddress, Address arrivalAddress, bool isActive)
        {
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            DestinationTime = destinationTime;
            Airplane = airplane;
            AirplaneId = airplane.Id;
            Airline = airline;
            AirlineId = airline.Name;
            DepartureAddress = departureAddress;
            ArrivalAddress = arrivalAddress;
            IsActive = isActive;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Flight() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public int Id { get; private set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DestinationTime { get; set; }
        public virtual Airplane Airplane { get; set; }
        public int AirplaneId { get; set; }
        public virtual Airline Airline { get; set; }
        public string AirlineId { get; set; }
        public Address DepartureAddress { get; set; }
        public Address ArrivalAddress { get; set; }
        public bool IsActive { get; set; }
        public void ChangeStatus(bool isActive)
        {
            IsActive = isActive;
        }
    }
}
