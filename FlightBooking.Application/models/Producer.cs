using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.models
{
    public class Producer
    {
        public Producer(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

    }
}
