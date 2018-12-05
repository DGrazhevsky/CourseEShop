using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using WineS.Models.Entities;

namespace WineS.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Укажите название")]
        public string Title { get; set; }

        [Display(Name = "Цена, в рублях")]
        [Required(ErrorMessage = "Укажите цену")]
        [Range(0, int.MaxValue, ErrorMessage = "Требуется положительное значение цены")]
        public int Price { get; set; }

        [Display(Name = "Произведено в")]
        [Required(ErrorMessage = "Укажите производителя")]
        public string Manufacturer { get; set; }

        [Display(Name = "Цвет")]
        [Required(ErrorMessage = "Укажите цвет")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Укажите дату")]
        public DateTime DateOfArrival { get; set; }

        public string Description { get; set; }
        public string Consist { get; set; }
        public byte[] Image { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<OrderProduct> ProductOrders { get; set; }
        public Product()
        {
            ProductOrders = new List<OrderProduct>();
        }
    }
}
