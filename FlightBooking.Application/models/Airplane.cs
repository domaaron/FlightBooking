using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.models
{
    [Table("Airplane")]
    public class Airplane
    {
        public Airplane(string name, Producer producer, int seats, double maxBaggageWeight)
        {
            Name = name;
            Producer = producer;
            ProducerId = producer.Name;
            Seats = seats;
            MaxBaggageWeight = maxBaggageWeight;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Airplane() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public int Id { get; private set; }
        public string Name { get; set; }
        public virtual Producer Producer { get; set; }
        public string ProducerId { get; set; }
        public int Seats { get; set; }
        public double MaxBaggageWeight { get; set; }    //Allowed max weight for each individual baggage
    }
}
