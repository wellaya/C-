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
    public class CategoryService : ICategoryService
    {
        ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public void Add(Category category)
        {
            this.categoryRepository.Add(category);
        }

        public void Edit(Category category)
        {
            this.categoryRepository.Edit(category);
        }

        public Category FindById(int id)
        {
            return this.categoryRepository.FindById(id);
        }

        public IEnumerable<Category> GetCategories()
        {
            return this.categoryRepository.GetCategories();
        }

        public void Remove(int id)
        {
            this.categoryRepository.Remove(id);
        }
    }
}
