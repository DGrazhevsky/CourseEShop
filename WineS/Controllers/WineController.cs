using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineS.Entities;
using WineS.Models.Pages;
using WineS.Models.Repositories;
using WineS.ViewModels;

namespace WineS.Controllers
{
    public class WineController : Controller
    {
        //private IProductRepository repository;
        //public int pageSize = 6;
        //public WineController(IProductRepository repo)
        //{
        //    repository = repo;
        //}

        //public ViewResult List(string winecolor, int page = 1)
        //{
        //    WineListViewModel model = new WineListViewModel
        //    {
        //        Wines = repository.Wines
        //            .Where(p => winecolor == null || p.WineColorId ==
        //            repository.WineColors.Where(c => c.Color == winecolor).Select(c => c.Id).Single())
        //            .OrderBy(wine => wine.Id)
        //            .Skip((page - 1) * pageSize)
        //            .Take(pageSize),
                
        //        PagingInfo = new Catalog
        //        {
        //            CurrentPage = page,
        //            ItemsPerPage = pageSize,
        //            //TotalItems = repository.Wines.Count()
        //            TotalItems = winecolor == null ?
        //             repository.Wines.Count() :
        //            repository.Wines
        //                         .Where(p => p.WineColorId ==
        //                  repository.WineColors.Where(c => c.Color == winecolor).Select(c => c.Id).Single()).Count()
        //        },
             
        //        currentColor = winecolor
        //    };
        //    return View(model);
        //}


    }
}