using Castle.Core.Resource;
using FlightBooking.Application.models;
using FlightBooking.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Test
{
    public class PassengerTest
    {
        [Fact]
        public void AddActiveBooking()
        {
            var date1 = new DateTime(2000, 1, 1);
            var arrivalTime = new DateTime(2023, 2, 1, 8, 30, 50);
            var departureTime = new DateTime(2023, 2, 1, 10, 30, 50);
            var destinationTime = new DateTime(2023, 2, 1, 15, 0, 0);

            var airline = new Airline("Austrian Airlines");
            var p1 = new Passenger("Max", "Mustermann", "1234567890", date1, new Address("Austria", "Vienna"), "1234567890", "max.mustermann@email.com");
            var producer1 = new Producer("Boeing");
            var plane1 = new Airplane("Boeing 777", producer1, 200, 23.0);
            var f1 = new Flight(departureTime, arrivalTime, destinationTime, plane1, airline, new Address("Austria", "Vienna"), new Address("Ireland", "Dublin"), 250.0M, true);
            var b1 = new Booking(f1, "C86", FlightClass.First);
            p1.PlaceBooking(b1);

            Assert.True(p1.CountBookings() == 1);
        }

        [Fact]
        public void AddCanceledBooking()
        {
            var date1 = new DateTime(2000, 1, 1);
            var arrivalTime = new DateTime(2023, 2, 1, 8, 30, 50);
            var departureTime = new DateTime(2023, 2, 1, 10, 30, 50);
            var destinationTime = new DateTime(2023, 2, 1, 15, 0, 0);

            var airline = new Airline("Austrian Airlines");
            var p2 = new AirlineEmployee(new Passenger("Erika", "Mustermann", "1234567890", date1, new Address("Austria", "Vienna"), "1234567890", "erika.mustermann@email.com"), airline, "Pilotin");
            var producer1 = new Producer("Boeing");
            var plane1 = new Airplane("Boeing 777", producer1, 200, 23.0);
            var f2 = new Flight(departureTime, arrivalTime, destinationTime, plane1, airline, new Address("Austria", "Vienna"), new Address("Finland", "Helsinki"), 400M, false);
            var b2 = new Booking(f2, "B04", FlightClass.Business);
            p2.PlaceBooking(b2);

            Assert.True(p2.CountBookings() == 0);
        }

        [Fact]
        public void CancelBooking()
        {
            var date1 = new DateTime(2000, 1, 1);
            var arrivalTime = new DateTime(2023, 2, 1, 8, 30, 50);
            var departureTime = new DateTime(2023, 2, 1, 10, 30, 50);
            var destinationTime = new DateTime(2023, 2, 1, 15, 0, 0);

            var airline = new Airline("Austrian Airlines");
            var p1 = new Passenger("Max", "Mustermann", "1234567890", date1, new Address("Austria", "Vienna"), "1234567890", "max.mustermann@email.com");
            var producer1 = new Producer("Boeing");
            var plane1 = new Airplane("Boeing 777", producer1, 200, 23.0);
            var f1 = new Flight(departureTime, arrivalTime, destinationTime, plane1, airline,new Address("Austria", "Vienna"), new Address("Ireland", "Dublin"), 250.0M, true);
            var b1 = new Booking(f1, "C86", FlightClass.First);
            p1.PlaceBooking(b1);
            p1.CancelBooking(b1);

            Assert.True(p1.CountBookings() == 0);
        }
    }
}
