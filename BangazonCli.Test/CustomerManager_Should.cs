using System;
using BangazonCli;
using System.Collections.Generic;
using Xunit;

namespace BangazonCli.Test
{
    public class CustomerManager_Should
    {
        private Customer _customer1;
        private Customer _customer2;
        private Customer _customer3;
                
        public CustomerManager_Should()
        {
            _customer1 = new Customer(
                1,
                "Chaz",
                "Vanderbilt",
                "2525 Moneystacks Way",
                "Brentwood",
                "TN",
                "37027",
                "615-555-1234",
                DateTime.Now,
                DateTime.Now
            );
            _customer2 = new Customer(
                2,
                "Pat",
                "Patterson",
                "1000 pats place",
                "Patland",
                "TN",
                "37327",
                "615-525-1234",
                DateTime.Now,
                DateTime.Now
            );
            _customer3 = new Customer(
                3,
                "Gilly",
                "Bibbons",
                "767 Woah ln",
                "Gallatin",
                "TN",
                "37327",
                "612-455-1234",
                DateTime.Now,
                DateTime.Now
            );
        }

        [Fact]
        public void Add_Should()
        {
            CustomerManager manager = new CustomerManager("BangazonTestDB");
            Customer newCustomer = manager.Add(_customer1);
            Assert.Equal("Chaz", newCustomer.FirstName);

        }

        [Fact]
        public void GetAllCustomers_Should()
        {
            
            CustomerManager manager = new CustomerManager("BangazonTestDB");
            manager.Add(_customer1);
            manager.Add(_customer2);
            manager.Add(_customer3);

            bool chazMadeIt = false;
            bool patMadeIt = false;
            bool terdMadeIt = false;
                        
            List<Customer> customerList = manager.GetAllCustomers(); 

            //if bob is in the list then set bobExists to true
            foreach(Customer c in customerList){
                if(c.FirstName == "Chaz" && c.LastName == "Vanderbilt" && c.Address == "2525 Moneystacks Way" && c.PhoneNumber=="615-555-1234"){
                    chazMadeIt = true;
                }

                if(c.FirstName == "Pat" && c.LastName == "Patterson" && c.Address == "1000 pats place" && c.PhoneNumber=="615-525-1234"){
                    patMadeIt = true;
                }

                if(c.FirstName == "Gilly" && c.LastName == "Bibbons" && c.Address == "767 Woah ln" && c.PhoneNumber=="612-455-1234"){
                    terdMadeIt = true;
                }

            }
            Assert.True(chazMadeIt);
            Assert.True(patMadeIt);
            Assert.True(terdMadeIt);
                                
        }

        [Fact]
        public void GetSingleCustomer_Should()
        {
            CustomerManager manager = new CustomerManager("BangazonTestDB");
            manager.Add(_customer1);
            Customer theCustomer = manager.GetSingleCustomer(1);

            Assert.Equal(1, theCustomer.Id);
            Assert.Equal("Chaz", theCustomer.FirstName);
            Assert.Equal("Vanderbilt", theCustomer.LastName);
            Assert.Equal("Brentwood", theCustomer.City);
            Assert.Equal("TN", theCustomer.State);
            Assert.Equal("37027", theCustomer.PostalCode);
            Assert.Equal("615-555-1234", theCustomer.PhoneNumber);
        }
        [Fact]
        public void ActivateCustomer_Should()
        {
            CustomerManager manager = new CustomerManager("BangazonTestDB");
            manager.Add(_customer1);
            manager.ActivateCustomer(1);

            Assert.Equal(1, manager.ActiveCustomer.Id);
        }

        

    }
}