using BLL.DTO;
using BLL.Interfaces;
using BLL_EF;
using Microsoft.AspNetCore.Mvc;

namespace JW_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketPositionsController : ControllerBase
    {
        readonly BasketPositionBLL _basketPositionBLL;

        public BasketPositionsController(BasketPositionBLL basketPositionBLL)
        {
            _basketPositionBLL = basketPositionBLL;
        }

        [HttpPost]
        public void Post([FromBody] BasketPositionDTORequest basketPositionDTORequest)
        {
            _basketPositionBLL.AddProductToBasket(basketPositionDTORequest);
        }

        [HttpDelete("{productId}")]
        public void DeleteProduct(int productId)
        {
            _basketPositionBLL.RemoveProductFromBasket(productId);
        }

        [HttpPut("Amount/{productId}")]
        public void UpdateAmountOfProduct(int productId,[FromBody] int amount)
        {
            _basketPositionBLL.UpdateAmountOfProduct(productId, amount);
        }

        [HttpGet("{userId}")]
        public IEnumerable<BasketPositionDTOResponse> GetUserBasket(int userId) 
        { 
            return _basketPositionBLL.GetBasket(userId);
        }

        [HttpPost("Order/{userId}")]
        public void Order (int userId)
        {
            _basketPositionBLL.Order(userId);
        }
    }
}
