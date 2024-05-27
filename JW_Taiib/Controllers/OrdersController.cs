using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JW_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class OrdersController : ControllerBase
    {
        readonly OrderBLL _orderBLL;

        public OrdersController(OrderBLL orderBLL)
        {
            _orderBLL = orderBLL;
        }

        [HttpGet]
        public IEnumerable<OrderDTOResponse> getAllOrders()
        {
            return _orderBLL.getAllOrders();
        }

        [HttpGet("{userId}")]
        public IEnumerable<OrderDTOResponse> getUserOrders(int userId)
        {
            return _orderBLL.getOrders(userId);
        }

        [HttpGet("{orderId}/Positions")]
        public IEnumerable<OrderPositionDTOResponse> getOrderPositions(int orderId)
        {
            return _orderBLL.getOrderPosition(orderId);
        }
    }
}
