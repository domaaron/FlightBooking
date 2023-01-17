using FlightBooking.Application.models;
using FlightBooking.models;

namespace FlightBooking.Test
{
    public class PassengerTest : DatabaseTest
    {
        public PassengerTest()
        {
            _db.Database.EnsureCreated();

            //Passenger
            var ps1 = new Passenger(new Person(firstName: "Max",
                                               lastName: "Mustermann",
                                               ssn: 123456789,
                                               birthDate: new DateTime(1990, 1, 1),
                                               address: new Address(State: "Austria", City: "Vienna"),
                                               tel: "123456789",
                                               email: "max.mustermann@mail.com"));

            var ps2 = new Passenger(new Person(firstName: "Erika",
                                              lastName: "Mustermann",
                                              ssn: 123456789,
                                              birthDate: new DateTime(1990, 1, 1),
                                              address: new Address(State: "Austria", City: "Vienna"),
                                              tel: "123456789",
                                              email: "erika.mustermann@mail.com"));
            _db.Persons.Add(ps1);
            _db.Persons.Add(ps2);

            //Producer
            var prd1 = new Producer(name: "Boeing");
            var prd2 = new Producer(name: "Airbus");
            
            _db.Producers.Add(prd1);
            _db.Producers.Add(prd2);

            //Airplane
            var airp1 = new Airplane(name: "Boeing 777",
                                    producer: prd1, 
                                    seats: 400,
                                    maxBaggageWeight: 30);

            var airp2 = new Airplane(name: "Airbus A380",
                                    producer: prd2,
                                    seats: 520,
                                    maxBaggageWeight: 50); 

            _db.Airplanes.Add(airp1);
            _db.Airplanes.Add(airp2);

            //Airline
            var airl1 = new Airline(name: "Austria Airlines");
            var airl2 = new Airline("Emirates Airline");

            _db.Airlines.Add(airl1);
            _db.Airlines.Add(airl2);

            //Flight
            var f1 = new Flight(departureTime: new DateTime(2023, 12, 31),
                                arrivalTime: new DateTime(2023, 12, 31),
                                destinationTime: new DateTime(2024, 1, 1),
                                airplane: airp1,
                                airline: airl1,
                                departureAddress: new Address("Austria", "Vienna"),
                                arrivalAddress: new Address("Finland", "Helsinki"),
                                isActive: true);

            var f2 = new Flight(departureTime: new DateTime(2024, 12, 31),
                                arrivalTime: new DateTime(2024, 12, 31),
                                destinationTime: new DateTime(2025, 1, 1),
                                airplane: airp2,
                                airline: airl2,
                                departureAddress: new Address("Austria", "Vienna"),
                                arrivalAddress: new Address("Spain", "Madrid"),
                                isActive: false);

            _db.Flights.Add(f1);
            _db.Flights.Add(f2);
            _db.SaveChanges();

            //Booking
            var b1 = new Booking(flight: f1,
                                 seatNumber: "CS8",
                                 FlightClass.Economy,
                                 price: 50);

            var b2 = new Booking(flight: f2,
                                 seatNumber: "B08",
                                 FlightClass.Business,
                                 price: 40);

            //PlaceBooking
            ps1.PlaceBooking(b1);
            ps2.PlaceBooking(b2);

            _db.SaveChanges();
        }

        [Fact]
        public void SetDataSuccessTest()
        {
            Assert.True(_db.Persons.Count() == 2);
            Assert.True(_db.Producers.Count() == 2);
            Assert.True(_db.Airplanes.Count() == 2);
            Assert.True(_db.Airlines.Count() == 2);
            Assert.True(_db.Flights.Count() == 2);
        }
        
        [Fact]
        public void AddActiveFlight()
        {
            Assert.True(_db.Passengers.ToList().First().CountBookings() == 1);
        }

        [Fact]
        public void AddCanceledFlight()
        {
            Assert.True(_db.Passengers.ToList().Last().CountBookings() == 0);
        }

        [Fact]
        public void CancelFlightSuccessTest()
        {
            var ps1 = _db.Passengers.First();
            ps1.CancelBooking(_db.Passengers.ToList().First().Bookings.First());

            Assert.True(_db.Passengers.ToList().First().CountBookings() == 0);
        }
        /*
        [Fact]
        public void ConfirmBookingSuccessTest()
        {
            var ps1 = _db.Passengers.First();
            ps1.ConfirmBooking(ps1.Bookings.First(), DateTime.Now, "Mastercard");

            Assert.True(ps1.Bookings.OfType<ConfirmedBooking>().Count() == 1);
        }
        */
    }
}
