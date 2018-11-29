using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineS.Entities;
using WineS.Models.Repositories;
using WineS.ViewModels;

namespace WineS.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;
        private IOrderRepository orderProcessor;

        public AdminController(IProductRepository repo, IOrderRepository repo1)
        {
            repository = repo;
            orderProcessor = repo1;
        }
        public ActionResult Index()
        {
            return RedirectToAction("Wines", "Admin");
        }


        //public ViewResult Wines()
        //{

        //    return View(new WineListViewModel
        //    {
        //        Wines = repository.Wines.OrderBy(c => c.Id),
        //        WineColor = repository.WineColors.OrderBy(c => c.Id),
        //        Sweetness = repository.Sweetnesses.OrderBy(v => v.Id)
        //    });
        //}
        
        //public ViewResult Orders()
        //{
        //    OrderListViewModel model = new OrderListViewModel
        //    {
        //        Orders = orderProcessor.Orders
        //            .OrderBy(order => order.Id),
        //        OrderWine = orderProcessor.OrderWines.OrderBy(order => order.OrderId),
        //        wine = repository.Wines
        //    };
        //    return View(model);
        //}

        //public ActionResult CheckOrder(int Id)
        //{
        //    orderProcessor.SaveOrders(Id);
        //    return RedirectToAction("Orders");
        //}

        //[HttpGet]
        //public ActionResult Edit(int? Id)
        //{

        //    if (Id == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    Wine wine = repository.Wines
        //        .FirstOrDefault(g => g.Id == Id);
        //    if (wine != null)
        //    {
        //        SelectList winecolors = new SelectList(repository.WineColors, "Id", "Color");
        //        SelectList sweets = new SelectList(repository.Sweetnesses, "Id", "Title");
        //        ViewBag.WineColor = winecolors;
        //        ViewBag.Sweets = sweets;
        //        return View(wine);
        //    }
        //    return RedirectToAction("Wines", "Admin");
        //}

        //[HttpPost]
        //public ActionResult Edit(Wine wine)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repository.SaveWine(wine);
        //        TempData["message"] = string.Format("Вино \"{0}\" было изменено", wine.Title);
        //        return RedirectToAction("Wines", "Admin");
        //    }
        //    else
        //    {
        //        // Что-то не так со значениями данных
        //        return View(wine);
        //    }
        //}

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    SelectList winecolors = new SelectList(repository.WineColors, "Id", "Color");
        //    SelectList sweets = new SelectList(repository.Sweetnesses, "Id", "Title");
        //    ViewBag.WineColor = winecolors;
        //    ViewBag.Sweets = sweets;
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(Wine newWine)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        repository.SaveWine(newWine);
        //        TempData["message"] = string.Format("Вино \"{0}\" было добавлено", newWine.Title);
        //        return RedirectToAction("Wines", "Admin");
        //    }
        //    else
        //    {
        //        return View(newWine);
        //    }
        //}


        //[HttpPost]
        //public ActionResult Delete(int Id)
        //{
        //    Wine deleteWine = repository.DeleteWine(Id);
        //    if (deleteWine != null)
        //    {
        //        TempData["message"] = string.Format("Вино \"{0}\" была удалено",
        //            deleteWine.Title);

        //    }
        //    return RedirectToAction("Wines", "Admin");
        //}

        //[HttpPost]
        //public ActionResult Delete(int Id)
        //{
        //    Wine deleteWine = repository.DeleteWine(Id);
        //    if (deleteWine != null)
        //    {
        //        TempData["message"] = string.Format("Вино \"{0}\" была удалено",
        //            deleteWine.Title);
        //    }
        //    return RedirectToAction("Wines", "Admin");
        //}








        //[HttpPost]
        //public ActionResult Edit(Wine wine, HttpPostedFileBase image = null)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (image != null)
        //        {
        //            wine.ImageMimeType = image.ContentType;
        //            wine.ImageData = new byte[image.ContentLength];
        //            image.InputStream.Read(wine.ImageData, 0, image.ContentLength);
        //        }
        //        repository.SaveWine(wine);
        //        TempData["message"] = string.Format("Вино \"{0}\" изменено и сохранено", wine.Title);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {

        //        return View(wine);
        //    }
        //




        //[HttpGet]
        //public ActionResult Edit(int? Id)
        //{

        //    if (Id == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    Wine wine = repository.Wines
        //        .FirstOrDefault(g => g.Id == Id);
        //    if (wine != null)
        //    {
        //        SelectList winecolors = new SelectList(repository.WineColors, "Id", "Color");
        //        SelectList sweets = new SelectList(repository.Sweetnesses, "Id", "Title");
        //        ViewBag.WineColor = winecolors;
        //        ViewBag.Sweets = sweets;
        //        return View(wine);
        //    }
        //    return RedirectToAction("Wines", "Admin");
        //}

        //[HttpPost]
        //public ActionResult Edit(Wine wine)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repository.SaveWine(wine);
        //        TempData["message"] = string.Format("Вино \"{0}\" было изменено", wine.Title);
        //        return RedirectToAction("Wines", "Admin");
        //    }
        //    else
        //    {
        //        // Что-то не так со значениями данных
        //        return View(wine);
        //    }
        //}

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    SelectList winecolors = new SelectList(repository.WineColors, "Id", "Color");
        //    SelectList sweets = new SelectList(repository.Sweetnesses, "Id", "Title");
        //    ViewBag.WineColor = winecolors;
        //    ViewBag.Sweets = sweets;
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(Wine newWine)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        repository.SaveWine(newWine);
        //        TempData["message"] = string.Format("Вино \"{0}\" было добавлено", newWine.Title);
        //        return RedirectToAction("Wines", "Admin");
        //    }
        //    else
        //    {
        //        return View(newWine);
        //    }
        //}


        //[HttpPost]
        //public ActionResult Delete(int Id)
        //{
        //    Wine deleteWine = repository.DeleteWine(Id);
        //    if (deleteWine != null)
        //    {
        //        TempData["message"] = string.Format("Вино \"{0}\" была удалено",
        //            deleteWine.Title);
        //    }
        //    return RedirectToAction("Wines", "Admin");
        //}
        //public ViewResult Finance()
        //{

        //    return View();
        //}
    }
}