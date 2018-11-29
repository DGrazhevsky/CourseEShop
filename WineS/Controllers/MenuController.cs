using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineS.Models.Repositories;

namespace WineS.Controllers
{
    public class MenuController : Controller
    {

        private IProductRepository repository;

        public MenuController(IProductRepository repo)
        {
            repository = repo;
        }


        //public PartialViewResult Menu(string winecolor = null)
        //{


        //    ViewBag.SelectedColor = winecolor;
        //    IEnumerable<string> winecolors = repository.WineColors
        //        .Select(wine => wine.Color)
        //        .Distinct()
        //        .OrderBy(x => x);

        //    return PartialView(winecolors);

        //}
    }
}
