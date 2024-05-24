using BLL.DTO;
using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore.Storage;
using Model;
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

        public void AddProductToBasket(BasketPositionDTORequest basketPositionDTORequest)
        {

            var user = db.Users.Find(basketPositionDTORequest.UserID);
            var product = db.Products.Find(basketPositionDTORequest.ProductID);

            bool flagAmountIncrease = false;


            if (user == null || product == null)
            {
                throw new Exception("Blad");
            }

            var pos = db.BasketPositions.Where(u => u.UserID == basketPositionDTORequest.UserID);
            if (pos != null)
            {
                foreach (var item in pos)
                {
                    var productId = item.ProductID;
                    if (productId == basketPositionDTORequest.ProductID)
                    {
                        item.Amount += basketPositionDTORequest.Amount;
                        flagAmountIncrease = true;
                        
                    }
                }
                db.SaveChanges();
            }
            if (!flagAmountIncrease)
            { 
                if (product.IsActive == true)
                {
                    var p = new BasketPosition
                    {
                        User = user,
                        UserID = basketPositionDTORequest.UserID,
                        Product = product,
                        ProductID = basketPositionDTORequest.ProductID,
                        Amount = basketPositionDTORequest.Amount
                    };
                    db.BasketPositions.Add(p);
                }
                db.SaveChanges();
            }
        }
        public void RemoveProductFromBasket(int id)
        {
            BasketPosition basketPosition = FindBasketPosition(id);
            db.BasketPositions.Remove(basketPosition);
            db.SaveChanges();
        }

        public void UpdateAmountOfProduct(int id, int amount)
        {
            BasketPosition basketPosition = FindBasketPosition(id);
            if (basketPosition.Amount > 0 && amount > 0)
                basketPosition.Amount = amount;
            db.SaveChanges();
        }

        public IEnumerable<BasketPositionDTOResponse> GetBasket(int idUser)
        {
            User user = db.Users.Find(idUser);
            if (user == null)
                throw new Exception($"Brak uzytkownika o id {idUser}");

            var pos = db.BasketPositions.Where(u=>u.UserID==idUser);
            return ToBasketPositionsDTOResponse(pos);
        }

        public void Order(int idUser)
        {
            User user = db.Users.Find(idUser);
            if (user == null)
                throw new Exception($"Brak uzytkownika o id {idUser}");

            var basketPositions = db.BasketPositions.Where(i=>i.UserID==idUser).ToList();

            Order newOrder = new Order
            {
                Date = DateTime.Now,
                User = user,
                UserID = idUser,
                Positions = new List<OrderPosition>()
            };

            List<OrderPosition> temp = new List<OrderPosition>();

            foreach(var basketPos in basketPositions)
            {
                var pr = db.Products.Find(basketPos.ProductID); if (pr == null) throw new Exception("Blad");
                var orPos = new OrderPosition
                {
                    Order = newOrder,
                    Amount = basketPos.Amount,
                    OrderID = newOrder.ID,
                    Product = pr,
                    ProductID = basketPos.ProductID,
                    Price = basketPos.Amount * pr.Price
                };
                db.OrderPositions.Add(orPos);
                db.SaveChanges();
                temp.Add(orPos);
                db.BasketPositions.Remove(basketPos);
                db.SaveChanges();
            }
            newOrder.Positions = temp;
            db.Orders.Add(newOrder);
           // db.SaveChanges();
        }

        BasketPosition FindBasketPosition(int id)
        {
            BasketPosition basketPosition = db.BasketPositions.Find(id);
            if(basketPosition == null)
            {
                throw new Exception($"Brak pozycji w koszyku o id {id}");
            }
            return basketPosition;
        }

        IEnumerable<BasketPositionDTOResponse> ToBasketPositionsDTOResponse(IEnumerable<BasketPosition> basketPositions)
        {
            List<BasketPositionDTOResponse> pos = new List<BasketPositionDTOResponse>();
            foreach (var basketPosition in basketPositions)
            {
                pos.Add(new BasketPositionDTOResponse
                {
                    ID = basketPosition.ID,
                    ProductID = basketPosition.ProductID,
                    UserID = basketPosition.UserID,
                    Amount = basketPosition.Amount
                });
            }
            return pos;
        }
    }
}
