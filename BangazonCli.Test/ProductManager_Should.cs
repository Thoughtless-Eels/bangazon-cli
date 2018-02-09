using System;
using BangazonCli;
using System.Collections.Generic;
using Xunit;

namespace BangazonCli.Test {
    public class ProductManager_Should {
        private Product _product;
        private Customer _customer;
        private DateTime dt = DateTime.Now;

        public void productConstructor () {
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
        }

        [Fact]
        public void CreateProduct () {
            // Assert.Contains (_product.Name, "Book");
        }

        [Fact]
        public void ListAllProducts () {
            ProductManager productmanager = new ProductManager ();
            productmanager.Add (_product);
            List<Product> listProduct = productmanager.GetAllProducts ();
            Assert.Contains (_product, listProduct);
        }

        [Fact]
        public void RemoveProduct () {
            ProductManager productmanager = new ProductManager ();
            productmanager.Add (_product);
            List<Product> listProduct = productmanager.GetAllProducts ();

            productmanager.RemoveSingleProduct (_product);

            Assert.DoesNotContain (_product, listProduct);
        }

        // [Fact]
        // public void UpdateProduct () {
        //     ProductManager productmanager = new ProductManager ();
        //     productmanager.Add (_product);
        //     List<Product> listProduct = productmanager.GetAllProducts ();

        //     productmanager.UpdateSingleProduct (_product);

        //     Assert.Equal (_product.Id, 1);
        // }


            // Pull the instance of _product and _customer together

            // Add the Customer.Id Key to the product. - .Add

            // Assert that the table contains CustomerId on product - Assert.
//             // Assert.Contains (_product.CustomerId, 4);
//    [Fact]
//         public void AddProductToCustomer()
//         {
//             ProductManager productmanager = new ProductManager();
//             manager.ProductManager(_product);

//             Assert.Contains(_product, manager._productManagerTable);
//         }

        [Fact]
        public void AddProductToOrder () {

        }
    }
}