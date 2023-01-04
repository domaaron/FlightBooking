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
    public class BookingTest
    {
        /*
        [Fact]
        public void CountBaggages()
        {
            var date1 = new DateTime(2000, 1, 1);
            var arrivalTime = new DateTime(2023, 2, 1, 8, 30, 50);
            var departureTime = new DateTime(2023, 2, 1, 10, 30, 50);
            var destinationTime = new DateTime(2023, 2, 1, 15, 0, 0);
            
            var p1 = new Passenger("Max", "Mustermann", "1234567890", date1, new Address("Austria", "Vienna"), "1234567890", "max.mustermann@email.com");
            var producer1 = new Producer("Boeing");
            var plane1 = new Airplane("Boeing 777", producer1, 200, 23.0);
            var f1 = new Flight(departureTime, arrivalTime, destinationTime, plane1, new Address("Austria", "Vienna"), new Address("Ireland", "Dublin"), 250.6M, true);
            var b1 = new Booking(f1, "C86", FlightClass.First);

            b1.AddBaggage(new Baggage("Cabin baggage", 5.3, 30));
            b1.AddBaggage(new Baggage("Cabin baggage", 4.7, 30));

            Assert.True(b1.CountBaggages() == 2);

            var p2 = new Passenger("Erika", "Mustermann", "1234567890", date1, new Address("Austria", "Vienna"), "1234567890", "max.mustermann@email.com");
            var producer2 = new Producer("Boeing");
            var plane2 = new Airplane("Boeing 777", producer2, 200, 23.0);
            var f2 = new Flight(departureTime, arrivalTime, destinationTime, plane2, new Address("Austria", "Vienna"), new Address("Finland", "Helsinki"), 250.0M, true);
            var b2 = new Booking(f2, "B04", FlightClass.Business);

            //Baggage will not be added because of its weight
            b2.AddBaggage(new Baggage("Cabin baggage", 500.0, 0));
        }
        */
        [Fact]
        public void CalculateTotalPriceTest()
        {
            var date1 = new DateTime(2000, 1, 1);
            var arrivalTime = new DateTime(2023, 2, 1, 8, 30, 50);
            var departureTime = new DateTime(2023, 2, 1, 10, 30, 50);
            var destinationTime = new DateTime(2023, 2, 1, 15, 0, 0);

            var airline = new Airline("Austrian Airlines");

            var p1 = new Passenger("Max", "Mustermann", "1234567890", date1, new Address("Austria", "Vienna"), "1234567890", "max.mustermann@email.com");
            var producer1 = new Producer("Boeing");
            var plane1 = new Airplane("Boeing 777", producer1, 200, 23.0);
            var f1 = new Flight(departureTime, arrivalTime, destinationTime ,plane1, airline, new Address("Austria", "Vienna"), new Address("Ireland", "Dublin"), 250.0M, true);
            var b1 = new Booking(f1, "C86", FlightClass.First);

            b1.AddBaggage(new Baggage("Cabin baggage", 5.3, 10M));
            b1.AddBaggage(new Baggage("Cabin baggage", 4.7, 0M));

            var b2 = new ConfirmedBooking(b1, DateTime.Now, "PayPal");

            Assert.True(b1.CountBaggages() == 2);
            //Assert.True(b2.CalculateTotalPrice() == 250M);
        }
    }
}
