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

        public PaymentTypeManager_Should()
        {

            _paymenttype = new PaymentType(
                1,
                "Visa",
                "3789122",
                1
            );
        }

// List Payment Type Manager:
[Fact]
        public void GetAllPaymentType_Should()
        {
            
            PaymentTypeManager manager = new PaymentTypeManager();

            manager.AddPaymentType(_paymenttype);
            List<PaymentType> paymentList = manager.GetAllPaymentTypes(); 
            Assert.Contains(_paymenttype, paymentList);
        }


// Add Payment Manager Should:
        [Fact]
        public void AddPaymentType_Should()
        {
            PaymentTypeManager manager = new PaymentTypeManager();
            manager.AddPaymentType(_paymenttype);

            Assert.Contains(_paymenttype, manager._paymentTypeTable);
        }

    }
}




