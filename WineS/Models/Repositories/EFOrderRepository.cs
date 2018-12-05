using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using WineS.Entities;
using WineS.Models.Context;
using WineS.Models.Entities;

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

            int maxId = context.Orders.Max(r => r.Id);
            maxId++;
            context.Orders.Add(new Order
                {
                Id = maxId,
                    DateOfOrder = DateTime.Today.Date,
                    City = shipinfo.City,
                    ShippAddress = shipinfo.AddressLine,
                    Country = shipinfo.Country,
                    Status = "Send",
                    UserId = HttpContext.Current.User.Identity.GetUserId().ToString()
                }
            );

  

        context.SaveChanges();
            foreach (var line in cart.Lines)
            {
                context.OrderProducts.Add(new OrderProduct
                    {
                        OrderId = context.Orders.Max(r => r.Id),
                        ProductId = line.Product.Id,
                        Size = line.Size,

                    }
                );
                //context.Products.Where(x => x.Id == line.Product.Id).First().Amount -= line.Quantity;
            };
            context.SaveChanges();

        }

        public void SaveOrders(int Id)
        {

            context.SaveChanges();


        }
    }
}