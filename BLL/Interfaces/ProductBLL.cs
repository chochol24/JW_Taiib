using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ProductBLL
    {
        public IEnumerable<ProductDTOResponse> GetProducts();
        public IEnumerable<ProductDTOResponse> GetProductsPage(int size, int count);
        public IEnumerable<ProductDTOResponse> GetProductsByName(string name);
        public IEnumerable<ProductDTOResponse> GetProductsIsActive(bool isActive);
        public IEnumerable<ProductDTOResponse> GetProductsSorted(string columnName, bool sort);

        public void AddProduct(ProductDTORequest product);
        public void AddProduct(string name, double price, string image, bool isActive);

        public void Updateproduct(int id, string name,double price, string image, bool isActive);
        public void DeleteProduct(int id);
        public void ActiveProduct(int id);

    }
}
