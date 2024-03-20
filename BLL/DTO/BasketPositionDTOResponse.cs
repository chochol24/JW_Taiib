﻿using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class BasketPositionDTOResponse
    {
        public int ID { get; set; }
        public Product Product { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int Amount { get; set; }

    }
}
