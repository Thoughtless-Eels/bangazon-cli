using System;
using BangazonCli;
using System.Collections.Generic;
using Xunit;

namespace BangazonCli.Test {
    public class ProductManager_Should {
        private Product _product;
        private DateTime dt = DateTime.Now;
   
        [Fact]
        public void CreateProduct () {
            Assert.Contains (_product.Name, "Book");
        }

        [Fact]
        public void AddCustomerProduct () {

        }

        [Fact]
        public void AddProductToOrder () {

        }
    }
}