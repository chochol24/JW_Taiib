using BLL.DTO;
using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            Product product = FindProduct(id);
            if (product.IsActive == false) 
                product.IsActive = true;
            db.SaveChanges();
        }

        public void AddProduct(ProductDTORequest product)
        {
            if(product.Price > 0)
            {
                db.Products.Add(new Product()
                {
                    Price = product.Price,
                    Name = product.Name,
                    Image = product.Image,
                    IsActive = product.IsActive
                });
            }
            db.SaveChanges();
        }


        public void Updateproduct(int id, ProductDTORequest productRequest)
        {
            Product product = FindProduct(id);
            if(product.Price>0)
            { 
                product.Price = productRequest.Price;
                product.Name = productRequest.Name;
                product.Image = productRequest.Image;
                product.IsActive = productRequest.IsActive;
                db.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            Product product = FindProduct(id);
            if(product == null)
            {
                throw new Exception($"Brak produktu o tym id");
            }


            if (db.BasketPositions.FirstOrDefault(o => o.ProductID == id) != null);
            else if (db.OrderPositions.FirstOrDefault(o => o.ProductID == id) != null)
                    product.IsActive = false;
            else
                db.Products.Remove(product);

            db.SaveChanges();
        }

        public IEnumerable<ProductDTOResponse> GetProducts(PaginationDTO pagination, string? nameFilter, bool? isActiveFilter, string? sortBy, bool sortAscending)
        {
            int count = pagination?.Count ?? 10;
            int page = pagination?.Page ?? 0; 

            IEnumerable<Product> products = db.Products.ToList();

            if (!string.IsNullOrEmpty(nameFilter))
                products = products.Where(p => p.Name.Contains(nameFilter));

            if (isActiveFilter.HasValue)
                products = products.Where(p => p.IsActive == isActiveFilter.Value);

            if(!string.IsNullOrEmpty(sortBy))
            {
                switch(sortBy)
                {
                    case "Name":
                        products = sortAscending ? products.OrderBy(p=>p.Name) : products.OrderByDescending(p=>p.Name); break;
                    case "Price":
                        products = sortAscending ? products.OrderBy(p => p.Price) : products.OrderByDescending(p => p.Price); break;
                    default:
                        products = products.OrderBy(p => p.ID); break;
                }
            }
            return products.Skip(count * page).Take(count).Select(x => ToProductResponseDTO(x));
        }

        Product FindProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
                throw new Exception($"Nie znaleziono produktu o id {id}");
            return product;
        }

        ProductDTOResponse ToProductResponseDTO(Product product)
        {
            return new ProductDTOResponse
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                IsActive = product.IsActive
            };
        }

    }
}
