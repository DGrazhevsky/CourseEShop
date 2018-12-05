using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineS.Entities;

namespace WineS.Models.Entities
{
    public class OrderProduct
    {
        public string Size { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}