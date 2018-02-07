using System;
using BangazonCli;
using System.Collections.Generic;
using Xunit;

namespace BangazonCli.Test {
    public class CustomerManager_Should {
        private Customer _customer;
        public CustomerManager_Should() {
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
        public void GetAllCustomers () {

            CustomerManager manager = new CustomerManager ();


            manager.Add (_customer);

            List<Customer> allCustomers = manager.GetAllCustomers ();

            Assert.Contains (_customer, allCustomers);
        }

        [Fact]
        public void GetSingleCustomer () {
            CustomerManager manager = new CustomerManager ();
            manager.Add (_customer);
            Customer theCustomer = manager.GetSingleCustomer (1);

            Assert.Equal (1, theCustomer.Id);
            Assert.Equal ("Chaz", theCustomer.FirstName);
            Assert.Equal ("Vanderbilt", theCustomer.LastName);
            Assert.Equal ("Brentwood",theCustomer.City);
            Assert.Equal ("TN", theCustomer.State);
            Assert.Equal ("37027", theCustomer.PostalCode);
            Assert.Equal ("615-555-1234",theCustomer.PhoneNumber);
        } 
        [Fact]
        public void ActivateCustomer () {

        }

        [Fact]
        public void AddCustomerPayment () {
            
        }

        [Fact]
        public void AddCustomerProduct () {

        }

        [Fact]
        public void AddProductToOrder () {

        }
        
        //Will this go in an OrderManager?
        [Fact]
        public void CompleteOrder () {

        }

    }
}