// Create a Model for the Payment Type Table:
using System;

namespace BangazonCli
{
    public class PaymentType
    {

        // Create a Primary Key for the Payment Type Id:
        public int Id { get; set; }

        // Properties for the PAayment Type Table:
        public string AccountNumber { get; set; }
        public string Name { get; set; }

        // Foreign Key: 
        public int CustomerId { get; set; }

        // Steves Code: Is this needed?
        // public Job ()
        // {
        //     this.Id = 1;
        //     this.Title = "test";
        //     this.Description = "test";
        //     this.CompanyId = 1;
        //     this.ResumeId = 1;
        // }

        // Constructor for Payment Type with it's parameters:
        public PaymentType(int id, string name, string accountNumber, int customerId)
        {
            this.Id = id;
            this.Name = name;
            this.AccountNumber = accountNumber;
            this.CustomerId = customerId;
        }
        public PaymentType(string name, string accountNumber, int customerId)
        {
            this.Name = name;
            this.AccountNumber = accountNumber;
            this.CustomerId = customerId;

        }
        public PaymentType()
        {
            this.Id = 0;
            this.Name = "";
            this.AccountNumber = "";
            this.CustomerId = 0;    
        }
    }
}