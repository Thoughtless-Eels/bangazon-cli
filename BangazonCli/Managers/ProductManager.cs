using System.Collections.Generic;
using System.Linq;

namespace BangazonCli {
    public class ProductManager {
        private List<Product> _productTable = new List<Product> ();

        public void Add (Product product) {
            _productTable.Add (product);
        }

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
    }
}