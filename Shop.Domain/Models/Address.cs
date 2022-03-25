using System;

namespace Shop.Domain.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

        private Address() { }

        public Address(string firstName, string lastName, string street, string city,
            string postCode, string country, string phoneNumber)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            PostCode = postCode;
            Country = country;
            PhoneNumber = phoneNumber;
        }
    }
}