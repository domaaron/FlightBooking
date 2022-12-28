using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.models
{
    public class ReviewedHandIn
    {
        public ReviewedHandIn(DateTime reviewDate, bool approved)
        {
            ReviewDate = reviewDate;
            Approved = approved;
        }
        public DateTime ReviewDate { get; set; }
        public bool Approved { get; set; }
    }
}
