using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface BasketPositionBLL
    {
        public void AddProductToBasket(ProductDTOResponse product);
        public void RemoveProductFromBasket(ProductDTOResponse product);
        public void RemoveProductFromBasket(int id);
        public void UpdateAmountOfProduct(int id, int amount);
        public IEnumerable<BasketPositionDTOResponse> GetBasket(UserDTOResponse user);
        public OrderDTORequest Order(UserDTOResponse user);

    }
}
