using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WineS.Models
{
    public class ShippingInfo
    {
    
        [Display(Name = "Адрес для доставки")]
        public string AddressLine { get; set; }
        [Display(Name = "Ваша страна")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Укажите город")]
        [Display(Name = "Ваш город")]
        public string City { get; set; }

    }
}