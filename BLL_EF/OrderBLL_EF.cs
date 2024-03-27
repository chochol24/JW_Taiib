using BLL.DTO;
using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class OrderBLL_EF : OrderBLL
    {
        private readonly WebShopContext db;

        public OrderBLL_EF(WebShopContext db)
        {
            this.db = db;
        }
        public void AddOrder(OrderDTORequest order)
        {
            db.Orders.Add(new Order()
            {
                User = order.User,
                UserID = order.UserID,
                Date = order.Date,
                Positions = (IEnumerable<OrderPosition>)order.Positions
            });
            
        }

        public IEnumerable<OrderDTOResponse> getAllOrders()
        {
            var users = db.Users.Include(u=>u.Orders).ThenInclude(o=>o.Positions).ToList();
            var orders = users.SelectMany(u=>u.Orders).ToList();
            return (IEnumerable<OrderDTOResponse>)orders;
        }

        public IEnumerable<OrderPositionDTOResponse> getOrderPosition(OrderDTOResponse order)
        {
            var or = db.Orders.Where(o=>o.ID==order.ID);
            var pos = or.SelectMany(o=>o.Positions).ToList();
            return (IEnumerable<OrderPositionDTOResponse>)pos;
        }

        public IEnumerable<OrderDTOResponse> getOrders(UserDTOResponse user)
        {
            var u = db.Users.FirstOrDefault(x => x.ID == user.ID);
            var orders = u.Orders;
            return (IEnumerable<OrderDTOResponse>)orders;
        }

    }
}
