using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineS.Models.Entities;


namespace WineS.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOfOrder { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ShippAddress { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public Order()
        {
            OrderProducts = new List<OrderProduct>();
        }
    }
}
