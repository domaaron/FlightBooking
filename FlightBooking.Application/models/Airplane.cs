using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.models
{
    public class Airplane
    {
        public Airplane(Producer producer, int seats)
        {
            Producer = producer;
            Seats = seats;
        }
        public Producer Producer { get; set; }
        public int Seats { get; set; }
    }
}
