using Bogus;
using FlightBooking.Application.models;
using FlightBooking.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person = FlightBooking.Application.models.Person;

namespace FlightBooking.Test
{
    public class BookingTests : DatabaseTest
    {
        public BookingTests()
        {
            _db.Database.EnsureCreated();

            //Passenger
            var ps1 = new Passenger(new Person(firstName: "Bob",
                                               lastName: "Mustermann",
                                               ssn: 123456789,
                                               birthDate: new DateTime(1990, 1, 1),
                                               address: new Address(State: "Austria", City: "Vienna"),
                                               tel: "123456789",
                                               email: "bob.mustermann@mail.com"));

            _db.Persons.Add(ps1);

            //Producer
            var prd1 = new Producer(name: "Airbus");

            _db.Producers.Add(prd1);

            //Airplane
            var airp1 = new Airplane(name: "Airbus A320",
                                    producer: prd1,
                                    seats: 520,
                                    maxBaggageWeight: 50);

            _db.Airplanes.Add(airp1);

            //Airline
            var airl1 = new Airline(name: "Turkish Airlines");

            _db.Airlines.Add(airl1);

            //Flight
            var f1 = new Flight(departureTime: new DateTime(2023, 12, 31),
                                arrivalTime: new DateTime(2023, 12, 31),
                                destinationTime: new DateTime(2024, 1, 1),
                                airplane: airp1,
                                airline: airl1,
                                departureAddress: new Address("Austria", "Vienna"),
                                arrivalAddress: new Address("Republic of Türkiye", "Ankara"),
                                isActive: true);


            _db.Flights.Add(f1);
            _db.SaveChanges();

            //Booking
            var b1 = new Booking(flight: f1,
                                 seatNumber: "CS8",
                                 FlightClass.Economy,
                                 price: 50);

            //PlaceBooking
            ps1.PlaceBooking(b1);

            //Baggage
            var bag1 = new Baggage("Hardside luggage", 4.19, 28);
            var bag2 = new Baggage("Softside luggage", 3.91, 25);

            _db.Baggages.Add(bag1);
            _db.Baggages.Add(bag2);

            //AddBaggage
            b1.AddBaggage(bag1);
            b1.AddBaggage(bag2);

            _db.SaveChanges();

            //ConfirmBooking
            ps1.ConfirmBooking(b1, DateTime.Now, "Mastercard");
        }

        [Fact]
        public void CountBaggagesSuccessTest()
        {
            Assert.True(_db.Bookings.ToList().First().CountBaggages() == 2);
        }

        
    }
}
