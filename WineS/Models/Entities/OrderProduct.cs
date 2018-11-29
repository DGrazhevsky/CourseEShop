using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.Entity;


namespace WineS.Entities
{
    public class OrderProduct
    {
        public int Amount { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        /* public static void AddOrder_Wine(AccountingContext db, ComboBox comboBox2, TextBox textBox1, ref double maxCost)
         {
             var order_wine = db.OrderWines.Where(x =>
             x.OrderId == db.Orders.Max(r => r.Id) &&
             x.WineId == db.Wines.Where(c => c.Title == comboBox2.SelectedItem.ToString())
                     .Select(c => c.Id).FirstOrDefault())
                     .FirstOrDefault();
             if (order_wine == null)
             {
                 order_wine = new OrderWine();
                 order_wine.OrderId = db.Orders.DefaultIfEmpty().Max(r => r == null ? 1 : r.Id);
                 order_wine.WineId = db.Wines.Where(c => c.Title == comboBox2.SelectedItem.ToString())
                     .Select(c => c.Id).FirstOrDefault();
                 order_wine.Amount = Convert.ToInt32(textBox1.Text);
                 db.OrderWines.Add(order_wine);
                 db.SaveChanges();
             }
             else
             {
                 order_wine.Amount += Int32.Parse(textBox1.Text);
                 db.SaveChanges();
             }
             maxCost += db.Wines.Where(c => c.Title == comboBox2.SelectedItem.ToString())
                     .Select(c => c.Price).FirstOrDefault() * Double.Parse(textBox1.Text);
         }

         public static void Remov(DataGridView dtp, AccountingContext db, ComboBox cmb2, ref double maxCost)
         {
             string temp = dtp[2, dtp.CurrentRow.Index].Value.ToString();
             OrderWine order_wine = db.OrderWines.Where(x =>
             x.OrderId == db.Orders.Max(r => r.Id) &&
             x.WineId == db.Wines.Where(c => c.Title == temp)
                     .Select(c => c.Id).FirstOrDefault())
                     .FirstOrDefault();
             maxCost -= Double.Parse(dtp[1, dtp.CurrentRow.Index].Value.ToString())* Double.Parse(dtp[0, dtp.CurrentRow.Index].Value.ToString());
             db.OrderWines.Remove(order_wine);
             db.SaveChanges();
         }


         public static void populateAll(DataGridView dvg, AccountingContext db, int id)
         {
             int temp = int.Parse(dvg[0, dvg.SelectedRows[0].Index].Value.ToString());
             var order_wine = (from x in db.OrderWines
                               where x.OrderId == temp
                               orderby x.OrderId
                               select new
                               {
                                   Номер = x.OrderId,
                                   Количество = x.Amount,
                                   Название = x.Wine.Title,
                                   Страна = x.Wine.Country,
                                   Год = x.Wine.Year,
                                   Объем = x.Wine.Capacity,
                                   Производитель = x.Wine.Manufacturer,
                                   Цвет = x.Wine.WineColor.Color,
                                   Сладость = x.Wine.Sweetness.Title
                               }).ToList();
             dvg.DataSource = order_wine;
         }

         public static void populateForAdd(DataGridView dvg, AccountingContext db)
         {
             var order_wine = (from c in db.OrderWines
                               where c.OrderId == db.Orders.Max((Order r) => r.Id)
                               select new
                               {
                                   Amount = c.Amount,
                                   Price = c.Wine.Price,
                                   Title = c.Wine.Title,
                                   Country = c.Wine.Country,
                                   Year = c.Wine.Year,
                                   Capacity = c.Wine.Capacity,
                                   Manufacturer = c.Wine.Manufacturer,
                                   Color = c.Wine.WineColor.Color,
                                   Sweetness = c.Wine.Sweetness.Title
                               }).ToList();
             dvg.DataSource = order_wine;
         }

         public static int SumOfWine(DateTime startTime, DateTime endTime, AccountingContext db)
         {
             int sum = 0;
             try
             {
                 sum = db.OrderWines.Where(x => x.Order.Date_Order >= startTime && x.Order.Date_Order <= endTime).Sum(x => x.Amount);

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.ToString());
             }
             return sum;
         }

         public static double MaxCost(DateTime startTime, DateTime endTime, AccountingContext db)
         {
             double max = 0;
             try
             {
                 max = db.Orders.Where(x => x.Date_Order >= startTime && x.Date_Order <= endTime).Max(x => x.Total_Cost);

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.ToString());
             }
             return max;
         }

         public static double TotalCost(DateTime startTime, DateTime endTime, AccountingContext db)
         {
             double total = 0;
             try
             {
                 total = db.Orders.Where(x => x.Date_Order >= startTime && x.Date_Order <= endTime).Sum(x=>x.Total_Cost);
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.ToString());
             }
             return total;
         }

         public static string MaxWine(DateTime startTime, DateTime endTime, AccountingContext db)
         {
             string name="";
             try
             {
                 //name = db.OrderWines.Where(x => x.Order.Date_Order >= startTime && x.Order.Date_Order <= endTime).GroupBy(x=>x.Wine.Title).Select(x => x.Sum)
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.ToString());
             }
             return name;
         }
         */
    }
}
