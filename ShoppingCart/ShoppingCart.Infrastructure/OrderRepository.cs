using ShoppingCart.Core.Interfaces.Repository;
using ShoppingCart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Infrastructure
{
    public class OrderRepository : IOrderRepository
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
        public void AddOrder(Order order)
        {
            Context.Orders.Add(order);
            Context.SaveChanges();
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            Context.OrderDetails.Add(orderDetail);
            Context.SaveChanges();
        }

        public Order GetPreviousOrder(string userName)
        {
            return Context.Orders.FirstOrDefault(x => x.UserName == userName);
        }

        public bool IsValidOder(int id, string userName)
        {
            return Context.Orders.Any(
                o => o.OrderId == id &&
                o.UserName == userName);
        }
    }
}
