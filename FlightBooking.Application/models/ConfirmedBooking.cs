using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.models
{
    public class ConfirmedBooking : Booking
    {
        public ConfirmedBooking(Booking booking, DateTime paymentDate, string paymentMethod) 
            : base(booking)
        {
            PaymentMethod = paymentMethod;
            PaymentDate = paymentDate;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected ConfirmedBooking() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }

        public decimal CalculateTotalPrice() => Baggages.Sum(b => b.Price) + Price;
        /*
        {
            
            if (booking != null)
            {
                decimal flightPrice = booking.Flight.Price;
                decimal baggagePrice = 0;

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
        */
    }
}
