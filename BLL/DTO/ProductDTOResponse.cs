using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ProductDTOResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string IsActive { get; set; }
        public IEnumerable<BasketPositionDTOResponse> BasketPositions { get; set; }
        public IEnumerable<OrderPositionDTOResponse> OrderPositions { get; set; }
    }
}
