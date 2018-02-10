using System;

namespace BangazonCli {
    public class Product {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int QuantitySold { get; set; }
        public DateTime CreatedOn { get; set; }

        // Constructor for Product accepting parameters
        public Product (int id, int customerId, double price, string name, string description, int quantity, int quantitySold, DateTime createdOn) {
            this.Id = id;
            this.CustomerId = customerId;
            this.Price = price;
            this.Name = name;
            this.Description = description;
            this.Quantity = quantity;
            this.QuantitySold = quantitySold;
            this.CreatedOn = createdOn;
        }

        public Product ()
        {
            this.Id = 0;
            this.CustomerId = 0;
            this.Price = 0;
            this.Name = "";
            this.Description = "";
            this.Quantity = 0;
            this.QuantitySold = 0;
            this.CreatedOn = DateTime.Today;
        }
    }
}