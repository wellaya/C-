using ShoppingCart.Core.Interfaces.Repository;
using ShoppingCart.Core.Interfaces.Service;
using ShoppingCart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core
{
    public class ProductService : IProductService
    {
        IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Add(Product product)
        {
            this.productRepository.Add(product);
        }

        public void Edit(Product product)
        {
            this.productRepository.Edit(product);
        }

        public Product FindById(int id)
        {
            return this.productRepository.FindById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.productRepository.GetProducts();
        }

        public void Remove(int id)
        {
            this.productRepository.Remove(id);
        }
    }
}
