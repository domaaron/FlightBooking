using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.models
{
    public class Payment
    {
        public Payment(Booking booking, double paymentAmount, DateTime paymentDate)
        {
            Booking = booking;
            PaymentAmount = paymentAmount;
            PaymentDate = paymentDate;
        }
        public Booking Booking { get; set; }
        public double PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}
