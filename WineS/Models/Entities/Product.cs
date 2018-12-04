using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Страна происхождения")]
        public string Country { get; set; }
        [Display(Name = "Произведено в")]
        [Required(ErrorMessage = "Укажите производителя")]
        public string Manufacturer { get; set; }
        [Display(Name = "Цвет")]
        [Required(ErrorMessage = "Укажите цвет")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Укажите дату")]
        public DateTime DateOfArrival { get; set; }
        [Display(Name = "Размер")]
        //[Required(ErrorMessage = "Укажите размер")]
        //public string Size { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    
        public byte[] Image { get; set; }
        [HiddenInput(DisplayValue = false)]
        public ICollection<OrderProduct> ProductOrders { get; set; }
        public Product()
        {
            ProductOrders = new List<OrderProduct>();
        }
    }
}
