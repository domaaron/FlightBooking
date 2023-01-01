using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.models
{
    public class Payment : Booking
    {
        public Payment(Booking booking, DateTime paymentDate) 
            : base(booking.Passenger, booking.Flight, booking.SeatNumber, booking.FlightClass)
        {
            PaymentDate = paymentDate;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Payment() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public DateTime PaymentDate { get; set; }
        public double CalculateTotalPrice(Booking booking)
        {
            if (booking != null)
            {
                double flightPrice = booking.Flight.Price;
                double baggagePrice = 0;

                foreach (Baggage b in booking.Baggages)
                {
                    baggagePrice += b.Price;
                }

                return flightPrice + baggagePrice;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
