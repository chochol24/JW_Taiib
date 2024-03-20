using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserDTORequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public Model.Type Type { get; set; }

        public IEnumerable<OrderPosition> Orders { get; set; }
        public IEnumerable<BasketPosition> BasketPositions { get; set; }
    }
}
