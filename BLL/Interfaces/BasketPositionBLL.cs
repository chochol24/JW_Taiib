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
        public void AddProductToBasket(BasketPositionDTORequest basketPositionDTORequest);
        public void RemoveProductFromBasket(int id);
        public void UpdateAmountOfProduct(int id, int amount);
        public IEnumerable<BasketPositionDTOResponse> GetBasket(int idUser);
        public void Order(int idUser);

    }
}
