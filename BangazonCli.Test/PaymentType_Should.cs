// Our Unit Test for the Payment Type_Should Unit Test:
using System;
using BangazonCli;
using System.Collections.Generic;
using Xunit;

namespace BangazonCli.Test
{
    public class PaymentType_Should
    {
        private PaymentType _paymenttype;
        public PaymentType_Should()
        {
            /*Properties of Payment Type :
            PK  PaymentTypeId
                Name
                Account Number
            FK  Customer ID 
            */

            // Create a new instance of a Payment Type and seed it with dummy data:
            _paymenttype = new PaymentType(
                1,
                "Visa",
                "3789122",
                1       
            );
        }


        // Assert what you want to run for your test:
        // We want to add a payment type to the customer:
        [Fact]
        public void CreatePaymentType()
        {
            Assert.Contains("Visa", _paymenttype.Name);
        }
    }
}

