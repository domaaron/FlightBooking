using FlightBooking.Application.models;
using FlightBooking.models;

namespace FlightBooking.Test
{
    public class FlightTests : DatabaseTest
    {
        public FlightTests() 
        {
            _db.Database.EnsureCreated();

            //Producer
            var prd1 = new Producer(name: "Boeing");

            _db.Producers.Add(prd1);

            //Airplane
            var airp1 = new Airplane(name: "Boeing 747",
                                    producer: prd1,
                                    seats: 364,
                                    maxBaggageWeight: 30);

            _db.Airplanes.Add(airp1);

            //Airline
            var airl1 = new Airline(name: "Level");

            _db.Airlines.Add(airl1);

            //Flight
            var f1 = new Flight(departureTime: new DateTime(2023, 12, 31),
                                arrivalTime: new DateTime(2023, 12, 31),
                                destinationTime: new DateTime(2024, 1, 1),
                                airplane: airp1,
                                airline: airl1,
                                departureAddress: new Address(State: "Austria", City: "Vienna"),
                                arrivalAddress: new Address(State: "France", City: "Nice"),
                                isActive: true);

            f1.ChangeStatus(false);
            _db.Flights.Add(f1);
            _db.SaveChanges();
        }

        [Fact]
        public void ChangeStatus()
        {
            Assert.True(_db.Flights.First().IsActive == false);
        }
    }
}
