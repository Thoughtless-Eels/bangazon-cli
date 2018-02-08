using System.Collections.Generic;
using System.Linq;

namespace BangazonCli
{
    public class PaymentTypeManager
    {

        // create an empty list that you can add your Payment Type info into:
        public List<PaymentType> _paymentTypeTable = new List<PaymentType>();
        public void AddPaymentType(PaymentType monkeybutt)
        {
            _paymentTypeTable.Add(monkeybutt);

        }

        public List<PaymentType> GetAllPaymentTypes()
        {
            return _paymentTypeTable;
            }



    }
}