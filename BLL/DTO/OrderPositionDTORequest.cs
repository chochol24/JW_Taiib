using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class OrderPositionDTORequest
    {
        public int OrderID { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int ProductID { get; set; }

    }
}
