using System;
using BangazonCli;
using System.Collections.Generic;
using Xunit;

namespace BangazonCli.Test {
    public class Customer_Should {
        private Customer _customer;
        public Customer_Should () {
            /*Constuctor Method :
            PK  CustomerId
                FirstName
                LastName
                City
                State
                PostalCode
                phone
                CreatedOn
                LastLogin
            */
            _customer = new Customer (
                1,
                "Chaz",
                "Vanderbilt",
                "Brentwood",
                "TN",
                "37027",
                "615-555-1234",
                DateTime.Now,
                DateTime.Now
            );
        }

        [Fact]
        public void CreateCustomer () {
            Assert.Contains (_customer.FirstName, "Chaz");
        }
    }
}