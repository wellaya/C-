using ShoppingCart.Core.Models;
using ShoppingCart.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShoppingCart.Core.Interfaces.Service
{
    public interface ICartService
    {
        CartRemoveViewModel AddCartItem(string cartId, int productId);
        void EmptyCart(string cartId);

        CartViewModel GetCart(string cartId);

        string GetCartId(HttpContextBase context);

        int GetCartItemCount(string cartId);

        List<Cart> GetCartItems(string cartId);

        CartRemoveViewModel RemoveCartItem(string cartId, int productId);
    }
}
