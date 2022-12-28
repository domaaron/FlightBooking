using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.models
{
    [Table("ReviewedHandIn")]
    public class ReviewedHandIn
    {
        public ReviewedHandIn(DateTime reviewDate, bool approved)
        {
            ReviewDate = reviewDate;
            Approved = approved;
        }

        protected ReviewedHandIn() { }

        public int Id { get; set; }
        public DateTime ReviewDate { get; set; }
        public bool Approved { get; set; }
    }
}
