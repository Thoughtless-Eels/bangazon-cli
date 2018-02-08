using System;

namespace BangazonCli {
    public class Customer {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastLogin { get; set; }

        // Constructor for Customer accepting parameters
        public Customer (int Id, string FirstName, string LastName, string City, string State, string PostalCode, string PhoneNumber,DateTime CreatedOn, DateTime LastLogin)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.City = City;
            this.State = State;
            this.PostalCode = PostalCode;
            this.PhoneNumber = PhoneNumber;
        }
    }
}