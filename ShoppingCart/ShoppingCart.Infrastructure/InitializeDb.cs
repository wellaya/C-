using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ShoppingCart.Infrastructure
{
    public class InitializeDb : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //GetCategories().ForEach(c => context.Categories.Add(c));
            //GetProducts().ForEach(p => context.Products.Add(p));
            //context.SaveChanges();
            base.Seed(context);
        }
    }
}
