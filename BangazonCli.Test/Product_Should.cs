using System;
using BangazonCli;
using System.Collections.Generic;
using Xunit;

namespace BangazonCli.Test {
    public class Product_Should {
        private Product _product;
        public DateTime dt = DateTime.Now;

        [Fact]
        public void Products_Should () {

            /*Constuctor Method :
            PK  ProductId
            FK  CustomerId
                Price
                Name
                Description
                Quantity
                QuantitySold
                CreatedOn
            */
            _product = new Product (
                1,
                4,
                12.55,
                "Book",
                "A Handcrafted book about See Sherp",
                2,
                72,
                dt
            );

            Assert.Equal (_product.Id, 1);
            Assert.Equal (_product.CustomerId, 4);
            Assert.Equal (_product.Price, 12.55);
            Assert.Equal (_product.Name, "Book");
            Assert.Equal (_product.Description, "A Handcrafted book about See Sherp");
            Assert.Equal (_product.Quantity, 2);
            Assert.Equal (_product.QuantitySold, 72);
            Assert.Equal (_product.CreatedOn, dt);

        }

    }
}