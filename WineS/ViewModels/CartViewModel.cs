using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineS.Models;

namespace WineS.ViewModels
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}