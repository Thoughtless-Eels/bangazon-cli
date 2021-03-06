// Create the Customer Model:

using System;

namespace BangazonCli {
    public class Customer {

        // Create a Private Key for the Customer Id:
        public int Id { get; set; }

        // Setting the Properties tied to Customer:
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastLogin { get; set; }

        // Constructor for Customer accepting parameters
        public Customer (int id, string firstName, string lastName, string address, string city, string state, string postalCode, string phoneNumber, DateTime createdOn, DateTime lastLogin)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.PostalCode = postalCode;
            this.PhoneNumber = phoneNumber;
            this.CreatedOn = CreatedOn;
            this.LastLogin = lastLogin;
        }

        public Customer (string firstName, string lastName, string address, string city, string state, string postalCode, string phoneNumber, DateTime createdOn, DateTime lastLogin)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.PostalCode = postalCode;
            this.PhoneNumber = phoneNumber;
            this.CreatedOn = CreatedOn;
            this.LastLogin = lastLogin;
        }

        public Customer ()
        {
            this.Id = 0;
            this.FirstName = "";
            this.LastName = "";
            this.Address = "";
            this.City = "";
            this.State = "";
            this.PostalCode = "";
            this.PhoneNumber = "";
            this.CreatedOn = DateTime.Now;
            this.LastLogin = DateTime.Now;
        }
    }
}