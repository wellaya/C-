using ShoppingCart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        void Edit(Category category);
        void Remove(int id);
        Category FindById(int id);
        IEnumerable<Category> GetCategories();
    }
}
