using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineS.Entities;
using WineS.Models.Entities;

namespace WineS.Models.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        IEnumerable<OrderProduct> OrderProducts { get; }

        void SendOrders(Cart cart, ShippingInfo shipinfo);
        void SaveOrders(int Id);
    }
}
