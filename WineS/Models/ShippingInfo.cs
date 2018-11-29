using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WineS.Models
{
    public class ShippingInfo
    {
        [Required(ErrorMessage = "Пожалуйста, напишите Ваше имя!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Нам нужен Ваш адрес для доставки!")]
        [Display(Name = "Адрес для доставки")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Адрес для доставки (дополнительное поле)")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        [Display(Name = "Ваш город")]
        public string City { get; set; }

    }
}