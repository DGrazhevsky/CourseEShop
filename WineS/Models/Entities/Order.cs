using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WineS.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public double Total_Cost { get; set; }
        public DateTime Date_Order { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string ShipAddress { get; set; }
        public bool? isChecked { get; set; }
        public ICollection<OrderProduct> OrderProducts{ get; set; }
        public Order()
        {
            OrderProducts = new List<OrderProduct>();
        }
    }
}
