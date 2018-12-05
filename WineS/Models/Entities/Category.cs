using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineS.Entities;

namespace WineS.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
    }
}