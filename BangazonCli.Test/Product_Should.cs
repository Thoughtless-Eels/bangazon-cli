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

            Assert.Equal (1, _product.Id);
            Assert.Equal (4, _product.CustomerId);
            Assert.Equal (12.55, _product.Price);
            Assert.Equal ("Book", _product.Name);
            Assert.Equal ("A Handcrafted book about See Sherp", _product.Description);
            Assert.Equal (2, _product.Quantity);
            Assert.Equal (72, _product.QuantitySold);
            Assert.Equal (dt, _product.CreatedOn);

        }

    }
}