using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface OrderBLL
    {
        public void AddOrder(UserDTOResponse user, OrderDTORequest order);
        public IEnumerable<OrderDTOResponse> getAllOrders();
        public IEnumerable<OrderDTOResponse> getOrders(UserDTOResponse user);
        public int getOrderPosition(OrderDTOResponse order);
    }
}
