using BLL.DTO;
using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class ProductBLL_EF : ProductBLL
    {
        private readonly WebShopContext db;

        public ProductBLL_EF(WebShopContext db)
        {
            this.db = db;
        }

        public void ActiveProduct(int id)
        {
            var product = db.Products.FirstOrDefault(p=>p.ID== id);
            if(product.IsActive==false)
                product.IsActive = true;
           
        }

        public void AddProduct(ProductDTORequest product)
        {
            if(product.Price>0)
            {
                db.Products.Add(new Model.Product()
                {
                    Price = product.Price,
                    Name = product.Name,
                    Image = product.Image,
                    IsActive = product.IsActive
                });
            }
            db.SaveChanges();
        }

        public void AddProduct(string name, double price, string image, bool isActive)
        {
            if (price > 0)
            {
                db.Products.Add(new Model.Product()
                {
                    Price = price,
                    Name = name,
                    Image = image,
                    IsActive = isActive
                });
            }
            db.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTOResponse> GetProducts()
        {

            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTOResponse> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTOResponse> GetProductsIsActive(bool isActive)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTOResponse> GetProductsPage(int size, int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTOResponse> GetProductsSorted(string columnName, bool sort)
        {
            throw new NotImplementedException();
        }

        public void Updateproduct(int id, string name, double price, string image, bool isActive)
        {
            throw new NotImplementedException();
        }
    }
}
