using System.Collections.Generic;
using System.Linq;

namespace BangazonCli {
    public class ProductManager {
        public List<Product> _productTable = new List<Product> ();

        public void Add (Product product) {
            _productTable.Add (product);
        }

        // public Product CreateProduct (int id, int customerid, double price, string name, string description, int quantity, int quantitysold, DateTime createdon) {

        //         Product _product = new Product ();
        //         return _product;
        // }


        public List<Product> GetAllProducts () {
            return _productTable;
        }

        public Product GetSingleProduct (int id) {
            return _productTable.Where (p => p.Id == id).Single ();
        }

        public void RemoveSingleProduct (Product product) {
            _productTable.Remove (product);
        }

        public void UpdatePrice (Product product, double price) {
            product.Price = price;
        }

        public void UpdateSingleProduct (Product product) {
            product.Id = 1;
        }
        public void AddProductToCustomer (Product product, Customer customer) {
            product.CustomerId = customer.Id;
        }
    }
}