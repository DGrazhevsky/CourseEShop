using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineS.Entities;

namespace WineS.Models.Context
{
    public class EntityFContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>().HasKey(pc => new { pc.OrderId, pc.ProductId });
            modelBuilder.Entity<OrderProduct>().HasRequired(pc => pc.Order).WithMany(p => p.OrderProducts).HasForeignKey(pc => pc.OrderId);

            modelBuilder.Entity<OrderProduct>().HasRequired(pc => pc.Product).WithMany(c => c.ProductOrders).HasForeignKey(pc => pc.ProductId);


        }

        public class MyContextInitializer : CreateDatabaseIfNotExists<EntityFContext>
        {
            protected override void Seed(EntityFContext db)
            {
                List<Product> product = new List<Product>
            {
              new Product { Id = 1, Title = "Сладкое", Country = "Kharkiv",
              Manufacturer = "Kek", Price = 2, Color = "White" },


        };


                foreach (Product sweet1 in product)
                    db.Products.Add(sweet1);

                db.SaveChanges();
                base.Seed(db);
            }
        }

    }
}

