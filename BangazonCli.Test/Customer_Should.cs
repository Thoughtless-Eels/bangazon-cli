using System;
using BangazonCli;
using Customer;
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
                "1962-11-25",
                "1992-01-22"
            );

        }

        [Fact]
        public void GetAllCustomers () {
            CustomerManager manager = new CustomerManager ();

            manager.Add (_customer);

            List<Customer> allCustomers = manager.GetAllCustomers ();

            Assert.Contains (_customer, allCustomers);
        }

        // [Fact]
        // public void GetSingleCustomer () {
        //     JobManager manager = new JobManager ();
        //     manager.Add (_job);
        //     Job theJob = manager.GetSingleJob (1);

        //     Assert.Equal (theJob.Id, 1);
        //     Assert.Equal (theJob.Description, "We need cheap labor");
        //     Assert.Equal (theJob.Title, "Junior Developer");

        // }

    }
}