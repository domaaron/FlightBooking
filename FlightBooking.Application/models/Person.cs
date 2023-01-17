using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.DataSets;

namespace FlightBooking.Application.models
{
    public record Address(string State, string City);
    [Table("Person")]
    public class Person
    {
        public Person(string firstName, string lastName, int ssn, DateTime birthDate, Address address, string tel, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            SSN = ssn;
            BirthDate = birthDate;
            Address = address;
            Tel = tel;
            Email = email;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Person() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public int Id { get; private set; }
        [MaxLength(64)]
        public string FirstName { get; set; }
        [MaxLength(64)]
        public string LastName { get; set; }
        public int SSN { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public string Tel { get; set; }
        [MaxLength(64)]
        public string Email { get; set; }
        public string PersonType { get; private set; } = default!;
    }
}
