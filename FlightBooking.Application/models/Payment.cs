using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.models
{
    [Table("Payment")]
    public class Payment
    {
        public Payment(Booking booking, DateTime paymentDate)
        {
            Booking = booking;
            BookingId = booking.Id;
            PaymentDate = paymentDate;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Payment() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public int Id { get; private set; }
        public Booking Booking { get; set; }
        public int BookingId { get; set; }
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
