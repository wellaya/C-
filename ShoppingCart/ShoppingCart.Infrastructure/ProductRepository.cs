using ShoppingCart.Core.Interfaces.Repository;
using ShoppingCart.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext context;

        public ApplicationDbContext Context {
            get
            {
                if (context == null)
                {
                    context = new ApplicationDbContext();
                }
                return context;
            }
        }
        public void Add(Product product)
        {
            Context.Products.Add(product);
            Context.SaveChanges();
        }

        public void Edit(Product product)
        {
            Context.Entry(product).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
        }

        public Product FindById(int id)
        {
            var p = (from item in Context.Products where item.Id == id select item).Include(x => x.Category).FirstOrDefault();
            return p;
        }

        public IEnumerable<Product> GetProducts()
        {
            return Context.Products.Include(x => x.Category);
        }

        public void Remove(int id)
        {
            var p = (Product)Context.Products.Find(id);
            Context.Products.Remove(p);
            Context.SaveChanges();
        }
    }
}
