using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Shop.Domain.Models
{
    public class Customer 
    {
        private List<Address> _addresses;
        private List<Order> _orders;
        
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual Cart Cart { get; set; }

        public IReadOnlyCollection<Address>  Addresses 
        { 
            get { return _addresses; }
        }

        public IReadOnlyCollection<Order> Orders
        {
            get { return _orders; }
        }

        private Customer()
        {}

        public Customer(User user, string firstName, string lastName, string phoneNumber)
        {
            User = user;
            SetDetails(firstName, lastName, phoneNumber);
        }

        public void SetDetails(string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
    }
}