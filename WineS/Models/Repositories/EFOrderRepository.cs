using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineS.Entities;
using WineS.Models.Context;

namespace WineS.Models.Repositories
{
    public class EFOrderRepository : IOrderRepository
    {
        EntityFContext context = new EntityFContext();

        public IEnumerable<Order> Orders
        {
            get { return context.Orders; }
        }

        public IEnumerable<OrderProduct> OrderProducts
        {
            get { return context.OrderProducts; }
        }

        public void SendOrders(Cart cart, ShippingInfo shipinfo)
        {


            context.Orders.Add(new Order
            {
                Date_Order = DateTime.Today.Date,
                FullName = shipinfo.Name,
                City = shipinfo.City,
                ShipAddress = shipinfo.AddressLine1 + shipinfo.AddressLine2,
                isChecked = false,
                Total_Cost = cart.ComputeTotalValue()
            }
            );
            context.SaveChanges();
            foreach (var line in cart.Lines)
            {
                context.OrderProducts.Add(new OrderProduct
                {
                    OrderId = context.Orders.Max(r => r.Id),
                    ProductId = line.Product.Id,
                    Amount = line.Quantity,

                }
                );
                    //context.Products.Where(x => x.Id == line.Product.Id).First().Amount -= line.Quantity;
            };
            context.SaveChanges();

        }

        public void SaveOrders(int Id)
        {

            context.Orders.Where(x => x.Id == Id).First().isChecked = true;
            context.SaveChanges();


        }
    }
}