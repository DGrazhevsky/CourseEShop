using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineS.Entities;
using WineS.Models.Pages;

namespace WineS.ViewModels
{
    public class ProductListViewModel
    {

        public IEnumerable<Product> Products { get; set; }
        public Product product;
        public Catalog PagingInfo { get; set; }
        public SelectList PageSizeList { get; set; }
        public string PageSize { get; set; }

        public SelectList PageSortList { get; set; }
        public string PageSort { get; set; }
        public IEnumerable<Product> RelatedProducts { get; set; }

        public string CategoryName { get; set; }
        public SelectList SizeList { get; set; }
        public string Size { get; set; }
    }
}