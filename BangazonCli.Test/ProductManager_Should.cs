using System;
using BangazonCli;
using System.Collections.Generic;
using Xunit;

namespace BangazonCli.Test {
    public class ProductManager_Should {
        private Product _product;
        private Customer _customer;
        private DateTime dt = DateTime.Now;

        public ProductManager_Should () {
            _product = new Product (
                1,
                1,
                12.55,
                "Book",
                "A Handcrafted book about See Sherp",
                2,
                72,
                dt
            );
            _customer = new Customer (
                1,
                "Chaz",
                "Vanderbilt",
                "Brentwood",
                "TN",
                "37027",
                "615-555-1234",
                DateTime.Now,
                DateTime.Now
            );
        }

        [Fact]
        public void AddProduct () {
            ProductManager productmanager = new ProductManager ("BangazonTestDB");
            Product newProduct = productmanager.Add (_product);
            Assert.Equal ("Book", newProduct.Name);
        }

        [Fact]
        public void ListAllProducts () {
            ProductManager productmanager = new ProductManager ("BangazonTestDB");
            productmanager.Add (_product);
            List<Product> listProduct = productmanager.GetAllProducts ();
            Assert.Contains (_product, listProduct);
        }

        [Fact]
        public void RemoveProduct () {
            ProductManager productmanager = new ProductManager ("BangazonTestDB");
            productmanager.Add (_product);
            List<Product> listProduct = productmanager.GetAllProducts ();

            productmanager.RemoveSingleProduct (_product);

            Assert.DoesNotContain (_product, listProduct);
        }

        [Fact]
        public void UpdateProduct () {
            ProductManager productmanager = new ProductManager ("BangazonTestDB");
            productmanager.Add (_product);
            List<Product> listProduct = productmanager.GetAllProducts ();

            productmanager.UpdateSingleProduct (_product);

            Assert.Equal (1, _product.Id);
        }
    }
}