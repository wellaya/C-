using ShoppingCart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core.Interfaces.Service
{
    public interface IProductService
    {
        void Add(Product product);
        void Edit(Product product);
        void Remove(int id);
        Product FindById(int id);
        IEnumerable<Product> GetProducts();

    }
}
