using BLL.DTO;
using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;

namespace BLL_EF
{
    public class OrderBLL_EF : OrderBLL
    {
        private readonly WebShopContext db;

        public OrderBLL_EF(WebShopContext db)
        {
            this.db = db;
        }

        public IEnumerable<OrderDTOResponse> getAllOrders()
        {
            var orders = db.Orders.ToList();
            return orders.Select(o=>ToOrderResponseDTO(o));
        }

        public IEnumerable<OrderDTOResponse> getOrders(int userId)
        {
            var u = db.Users.Find(userId);
            if (u == null)
                throw new Exception($"Brak usera o id {userId}");
            var orders = db.Orders.Where(u=>u.UserID==userId).ToList();
            return orders.Select(o=>ToOrderResponseDTO(o));
        }

        public IEnumerable<OrderPositionDTOResponse> getOrderPosition(int orderId)
        {
            var or = db.Orders.Find(orderId);
            if (or == null)
                throw new Exception($"Brak zamowienia o id {orderId}");
            var pos = db.OrderPositions.Where(o=>o.OrderID==orderId).ToList();

            return ToOrderPositionsDTOResponse(pos);
        }

        
        OrderDTOResponse ToOrderResponseDTO(Order order)
        {
            return new OrderDTOResponse
            {
                ID = order.ID,
                UserID = order.UserID,
                Date = order.Date,
            };
        }

        IEnumerable<OrderPositionDTOResponse> ToOrderPositionsDTOResponse(List<OrderPosition> orderPositions)
        {
            List<OrderPositionDTOResponse> pos = new List<OrderPositionDTOResponse>();
            foreach (var orderPosition in orderPositions)
            {
                pos.Add(new OrderPositionDTOResponse
                {
                    ID = orderPosition.ID,
                    ProductID = orderPosition.ProductID,
                    Amount = orderPosition.Amount,
                    Price = orderPosition.Price,
                    OrderID = orderPosition.OrderID,
                });
            }
            return pos;
        }
    }
}
