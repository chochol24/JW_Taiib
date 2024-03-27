using BLL.DTO;
using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class BasketPositionBLL_EF : BasketPositionBLL
    {

        private readonly WebShopContext db;

        public BasketPositionBLL_EF(WebShopContext db)
        {
            this.db = db;
        }

        public void AddProductToBasket(ProductDTOResponse product)
        {
            if (product.Price > 0)
                
            throw new NotImplementedException();
        }

        public IEnumerable<BasketPositionDTOResponse> GetBasket(UserDTOResponse user)
        {
            throw new NotImplementedException();
        }

        public OrderDTORequest Order(UserDTOResponse user)
        {
            var u = db.Users.FirstOrDefault(o=>o.ID == user.ID);
            OrderDTORequest order = new OrderDTORequest();
            //var orderPositions = db.BasketPositions.SelectMany(o => o.UserID = user.ID);

            throw new NotImplementedException();
        }

        public void RemoveProductFromBasket(ProductDTOResponse product)
        {
            throw new NotImplementedException();

        }

        public void RemoveProductFromBasket(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAmountOfProduct(int id, int amount)
        {
            throw new NotImplementedException();
        }
    }
}
