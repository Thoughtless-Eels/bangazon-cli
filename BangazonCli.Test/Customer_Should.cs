// Our Unit Test for the Customer Table:
using System;
using BangazonCli;
// using BangazonCLI;
using System.Collections.Generic;
using Xunit;

namespace BangazonCli.Test
{
    public class Customer_Should
    {
        private Customer _customer;
        public Customer_Should()
        {
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

            // Create a new instance of a customer and seed it with dummy data:
            _customer = new Customer(
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
        // Assert what you want to run for your test:
        // Add properties to the instance you created:
        [Fact]
        public void CreateCustomer()
        {
            Assert.Contains(_customer.FirstName, "Chaz");
        }
    }
}