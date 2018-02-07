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
        public Product (int Id, int CustomerId, double Price, string Name, string Description, int Quantity, int QuantitySold, DateTime CreatedOn) {
            this.Id = Id;
            this.CustomerId = CustomerId;
            this.Price = Price;
            this.Name = Name;
            this.Description = Description;
            this.Quantity = Quantity;
            this.QuantitySold = QuantitySold;
            this.CreatedOn = CreatedOn;
        }
    }
}