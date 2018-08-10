using ShoppingCart.Core.Interfaces.Repository;
using ShoppingCart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Infrastructure
{
    public class CartRepository : ICartRepository
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
        public int AddCartItem(string cartId, int productId)
        {
            var item = Context.Carts.SingleOrDefault(x => x.CartId == cartId && x.ProductId == productId);
            if (item == null)
            {
                item = new Cart
                {
                    CartId = cartId,
                    ProductId = productId,
                    CreatedDate = DateTime.Now,
                    Count = 1
                };
                Context.Carts.Add(item);
            }
            else
            {
                item.Count++;
            }
            Context.SaveChanges();
            return item.Count;
        }

        public void EmptyCart(string cartId)
        {
            var carts = Context.Carts.Where(x => x.CartId == cartId);
            foreach (var item in carts)
            {
                Context.Carts.Remove(item);
            }
            Context.SaveChanges();
        }

        public int GetCartItemCount(string cartId)
        {
            int? count =  (from item in Context.Carts where item.CartId == cartId select (int?)item.Count).Sum();
            return count ?? 0;
        }

        public List<Cart> GetCartItems(string cartId)
        {
            return Context.Carts.Where(x => x.CartId == cartId).ToList();
        }

        public decimal GetCartTotal(string cartId)
        {
            decimal? total = (from item in Context.Carts where item.CartId == cartId select (int?)item.Count * item.Product.Price).Sum();
            return total ?? decimal.Zero;
        }

        public int RemoveCartItem(string cartId, int productId)
        {
            var item = Context.Carts.Where(x => x.CartId == cartId && x.ProductId == productId).SingleOrDefault();
            int itemCount = 0;
            if (item != null)
            {
                if (item.Count > 1)
                {
                    item.Count--;
                    itemCount = item.Count;
                }
                else
                {
                    Context.Carts.Remove(item);
                }
            }
            
            Context.SaveChanges();
            return itemCount;
        }
    }
}
