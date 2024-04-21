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
        public IEnumerable<ProductDTOResponse> GetProducts(PaginationDTO pagination, string nameFilter, bool? isActiveFilter, string sortBy, bool sortAscending);
        public void AddProduct(ProductDTORequest product);
        public void Updateproduct(int id, ProductDTORequest product);
        public void DeleteProduct(int id);
        public void ActiveProduct(int id);

    }
}
