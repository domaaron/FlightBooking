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
        public Payment(Booking booking, double paymentAmount, DateTime paymentDate)
        {
            Booking = booking;
            BookingId = booking.Id;
            PaymentAmount = paymentAmount;
            PaymentDate = paymentDate;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Payment() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public int Id { get; private set; }
        public Booking Booking { get; set; }
        public int BookingId { get; set; }
        public double PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}
