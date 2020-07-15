using Microsoft.EntityFrameworkCore;

namespace DTO.Entities
{
    [Owned]
    public class Address
    {
        public string Number { get; private set; }
        public string Street { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }

        public Address()
        {

        }

        public Address(string number, string street, string city, string state, string country)
        {
            Number = number;
            Street = street;
            City = city;
            State = state;
            Country = country;
        }
    }
}