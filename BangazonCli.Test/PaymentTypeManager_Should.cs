// Our Unit Test for the Payment Type Manager_Should Unit Test:
using System;
using BangazonCli;
using System.Collections.Generic;
using Xunit;

namespace BangazonCli.Test.bin
{
    public class PaymentTypeManager_Should
    {
        private PaymentType _paymenttype;
        private Customer _customer;

        public PaymentTypeManager_Should()
        {

            _paymenttype = new PaymentType(
                1,
                "Visa",
                "3789122",
                1
            );

            _customer = new Customer(
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

        // List Payment Type Manager:
        [Fact]
        public void GetAllPaymentType_Should()
        {
            PaymentTypeManager manager = new PaymentTypeManager("BangazonTestDB");

            manager.AddPaymentType(_paymenttype);
            List<PaymentType> paymentList = manager.GetAllPaymentTypes();
            Assert.Contains(_paymenttype, paymentList);
        }


        // Add Payment Manager Should:
        [Fact]
        public void AddPaymentType_Should()
        {
            CustomerManager custManager = new CustomerManager("BangazonTestDB");
            PaymentTypeManager manager = new PaymentTypeManager("BangazonTestDB");
            Customer newCust = custManager.Add(_customer);
            custManager.ActivateCustomer(newCust.Id);

            PaymentType _paymentType2 = new PaymentType(
                "AMEX",
                "172635",
                custManager.ActiveCustomer.Id
            );

            PaymentType newPaymentType = manager.AddPaymentType(_paymentType2);

            Assert.Equal("AMEX", newPaymentType.Name);
            Assert.Equal(custManager.ActiveCustomer.Id, newPaymentType.CustomerId);
        }

    }
}




