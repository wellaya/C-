using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Infrastructure
{
    public abstract class AbstractRepository
    {
        private ApplicationDbContext dbContext;

        public AbstractRepository()
        {

        }
        public ApplicationDbContext CreateContext()
        {
            if (this.dbContext == null)
            {
                this.dbContext = new ApplicationDbContext();
            }

            //  var context = new Context();
            return this.dbContext;
        }
    }
}
