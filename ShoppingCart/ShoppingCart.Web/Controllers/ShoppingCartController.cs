using ShoppingCart.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        ICartService service;
        public ShoppingCartController(ICartService service)
        {
            this.service = service;
        }
        // GET: ShoppingCart
        public ActionResult Index()
        {
            string id = this.service.GetCartId(this.HttpContext);
            var viewModel = this.service.GetCart(id);
            return View(viewModel);
        }
    }
}