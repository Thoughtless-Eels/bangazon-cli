using System;

namespace BangazonCli
{
    public class PaymentType
    {
        public int PaymentTypeId { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public PaymentType(int id, string name, string accountNumber, int customerId)
        {
            this.PaymentTypeId = id;
            this.Name = name;
            this.AccountNumber = accountNumber;
            this.CustomerId = customerId;
        }
    }
}