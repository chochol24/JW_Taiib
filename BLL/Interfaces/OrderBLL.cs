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
        public IEnumerable<OrderDTOResponse> getAllOrders();
        public IEnumerable<OrderDTOResponse> getOrders(int id);
        public IEnumerable<OrderPositionDTOResponse> getOrderPosition(int id);
    }
}
