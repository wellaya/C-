using ShoppingCart.Core.Interfaces.Repository;
using ShoppingCart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Infrastructure
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext context;

        public ApplicationDbContext Context
        {
            get
            {
                if (context == null)
                {
                    context = new ApplicationDbContext();
                }
                return context;
            }
        }
        public void Add(Category category)
        {
            Context.Categories.Add(category);
            Context.SaveChanges();
        }

        public void Edit(Category category)
        {
            Context.Entry(category).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
        }

        public Category FindById(int id)
        {
            var result = (from r in Context.Categories where r.Id == id select r).FirstOrDefault();
            return result;
        }

        public IEnumerable<Category> GetCategories()
        {
            return Context.Categories;
        }

        public void Remove(int id)
        {
            var c = (Category)Context.Categories.Find(id);
            Context.Categories.Remove(c);
            Context.SaveChanges();
        }
    }
}
