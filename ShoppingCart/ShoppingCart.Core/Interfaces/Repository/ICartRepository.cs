using ShoppingCart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core.Interfaces.Repository
{
    public interface ICartRepository
    {
        int AddCartItem(string cartId, int productId);
        void EmptyCart(string cartId);

        decimal GetCartTotal(string cartId);

        int GetCartItemCount(string cartId);

        List<Cart> GetCartItems(string cartId);

        int RemoveCartItem(string cartId, int productId);
    }
}
