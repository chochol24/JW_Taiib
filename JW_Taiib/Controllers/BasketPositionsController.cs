using BLL.DTO;
using BLL.Interfaces;
using BLL_EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JW_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize(Roles = "admin")]
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

        [HttpDelete("{basketPositionId}")]
        public void DeleteProduct(int basketPositionId)
        {
            _basketPositionBLL.RemoveProductFromBasket(basketPositionId);
        }

        [HttpPut("Amount/{basketPositionId}")]
        public void UpdateAmountOfProduct(int basketPositionId,[FromBody] int amount)
        {
            _basketPositionBLL.UpdateAmountOfProduct(basketPositionId, amount);
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
