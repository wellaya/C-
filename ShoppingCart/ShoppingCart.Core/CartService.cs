using ShoppingCart.Core.Interfaces.Repository;
using ShoppingCart.Core.Interfaces.Service;
using ShoppingCart.Core.Models;
using ShoppingCart.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShoppingCart.Core
{
    public class CartService : ICartService
    {
        IProductRepository productRepository;
        ICartRepository cartRepository;
        public const string CartIdSessionKey = "CartId";
        public CartService(IProductRepository productRepository, ICartRepository cartRepository)
        {
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
        }
        public CartRemoveViewModel AddCartItem(string cartId, int productId)
        {
            CartRemoveViewModel cartRemove = new CartRemoveViewModel();
            cartRemove.ItemCount = cartRepository.AddCartItem(cartId, productId);
            cartRemove.CartCount = cartRepository.GetCartItemCount(cartId);
            cartRemove.CartTotal = cartRepository.GetCartTotal(cartId);
            cartRemove.DeleteId = productId;
            var prod = productRepository.FindById(productId);
            cartRemove.Message = prod.Name + " has been added to your shopping cart.";
            return cartRemove;
        }

        public void EmptyCart(string cartId)
        {
            cartRepository.EmptyCart(cartId);
        }

        public CartViewModel GetCart(string cartId)
        {
            CartViewModel cart = new CartViewModel();
            cart.CartItems = cartRepository.GetCartItems(cartId);
            cart.CartTotal = cartRepository.GetCartTotal(cartId);
            return cart;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartIdSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartIdSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid newId = Guid.NewGuid();
                    context.Session[CartIdSessionKey] = newId;
                }
            }

            return context.Session[CartIdSessionKey].ToString();
        }

        public int GetCartItemCount(string cartId)
        {
            return this.cartRepository.GetCartItemCount(cartId);
        }

        public List<Cart> GetCartItems(string cartId)
        {
            return cartRepository.GetCartItems(cartId);
        }

        public CartRemoveViewModel RemoveCartItem(string cartId, int productId)
        {
            CartRemoveViewModel cartRemove = new CartRemoveViewModel();
            cartRemove.ItemCount = cartRepository.RemoveCartItem(cartId, productId);
            cartRemove.CartCount = cartRepository.GetCartItemCount(cartId);
            cartRemove.CartTotal = cartRepository.GetCartTotal(cartId);
            cartRemove.DeleteId = productId;
            var prod = productRepository.FindById(productId);
            cartRemove.Message = "One (1) " + prod.Name + " has been removed from your shopping cart.";
            return cartRemove;
        }
    }
}
