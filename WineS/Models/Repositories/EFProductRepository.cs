using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineS.Entities;
using WineS.Models.Context;

namespace WineS.Models.Repositories
{

    public class EFProductRepository : IProductRepository
    {
        EntityFContext context = new EntityFContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }


        public Product getProduct(int Id)
        {
            return context.Products.Where(x => x.Id == Id).First();
        }





        public IEnumerable<Order> Orders
        {
            get { return context.Orders; }
        }

        public IEnumerable<OrderProduct> OrderProducts
        {
            get { return context.OrderProducts; }
        }



        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
                context.Products.Add(product);
            else
            {
                Product dbEntry = context.Products.Find(product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Title = product.Title;

                    dbEntry.Country = product.Country;
                    dbEntry.Manufacturer = product.Manufacturer;
                    ;
                    dbEntry.Price = product.Price;
                    dbEntry.Color = product.Color;
      
         
                    dbEntry.Description = product.Description;
                    dbEntry.Category = product.Category;
                    dbEntry.DateOfArrival = product.DateOfArrival;
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int Id)
        {
            Product dbEntry = context.Products.Find(Id);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


    }
}