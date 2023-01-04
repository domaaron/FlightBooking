using FlightBooking.Application.models;
using FlightBooking.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Test
{
    public class FlightTest
    {
        [Fact]
        public void ChangeStatus()
        {
            var arrivalTime = new DateTime(2023, 2, 1, 8, 30, 50);
            var departureTime = new DateTime(2023, 2, 1, 10, 30, 50);
            var destinationTime = new DateTime(2023, 2, 1, 15, 0, 0);

            var airline = new Airline("Austrian Airlines");

            var producer1 = new Producer("Boeing");
            var plane1 = new Airplane("Boeing 777", producer1, 200, 23.0);
            var f1 = new Flight(departureTime, arrivalTime, destinationTime, plane1, airline, new Address("Austria", "Vienna"), new Address("Ireland", "Dublin"), 250.0M, true);

            f1.ChangeStatus(false);

            Assert.True(f1.IsActive == false);
        }
    }
}
