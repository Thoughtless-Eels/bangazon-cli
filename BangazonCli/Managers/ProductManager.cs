using System.Collections.Generic;
using System.Linq;

namespace BangazonCli
{
    public class ProductManager
    {
        private List<Product> _productTable = new List<Product>();

        public void Add(Product ToothBrush)
        {
            _productTable.Add(ToothBrush);
        }
        
        public List<Product> GetAllProducts ()
        {
            return _productTable;
        }

        public Product GetSingleProduct(int id)
        {
            return _productTable.Where(p => p.Id == id).Single();
        }



        public void UpdatePrice(Product product, double price)
        {
            product.Price = price;
        }
    }
}