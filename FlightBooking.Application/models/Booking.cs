﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.models
{
    [Table("Booking")]
    public class Booking
    {
        private readonly List<Baggage> _baggages = new();
        public Booking(Passenger passenger, Flight flight, string seatNumber, FlightClass flightClass)
        {
            Passenger = passenger;
            PassengerId = passenger.Id;
            Flight = flight;
            FlightId = flight.Id;
            SeatNumber = seatNumber;
            FlightClass = flightClass;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Booking() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public int Id { get; set; }
        public Passenger Passenger { get; set; }
        public int PassengerId { get; set; }
        public Flight Flight { get; set; }
        public int FlightId { get; set; }
        public string SeatNumber { get; set; }
        public FlightClass FlightClass { get; set; }
        public IReadOnlyList<Baggage> Baggages => _baggages;

        public void AddBaggage(Baggage b)
        {
            _baggages.Add(b);
        }
    }
}