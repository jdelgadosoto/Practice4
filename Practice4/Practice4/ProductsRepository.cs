using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4
{
    public interface IProductRepository
    {
        void AddProduct(Products product);
        void RemoveProduct(int id);
        List<Products> GetAllProducts();
        Products GetProductById(int id);
    }



    public class ProductRepository : IProductRepository
    {
        public List<Products> _products = new List<Products>();
        
        public void AddProduct(Products product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductID == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public List<Products> GetAllProducts()
        {
            return _products;
        }

        public Products GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.ProductID == id);
        }
    }
}
