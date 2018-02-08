// Create the Customer Model:

using System;

namespace BangazonCli {
    public class Customer {

        // Create a Private Key for the Customer Id:
        public int Id { get; set; }

        // Setting the Properties tied to Customer:
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastLogin { get; set; }

        // Constructor for Customer accepting parameters
        public Customer (int id, string firstName, string lastName, string city, string state, string postalCode, string phoneNumber,DateTime createdOn, DateTime lastLogin)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.City = city;
            this.State = state;
            this.PostalCode = postalCode;
            this.PhoneNumber = phoneNumber;
        }
    }
}