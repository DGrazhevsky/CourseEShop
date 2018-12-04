using System;
using System.CodeDom;
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
    public class ProductController : Controller
    {
  
        private IProductRepository repository;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        //private IProductRepository repository;
        //public int pageSize = 6;
        //public WineController(IProductRepository repo)
        //{
        //    repository = repo;
        //}
        [HttpPost]
        public JsonResult ChangePageItems(ProductListViewModel plvm)
        {
            var pageSize = plvm.PageSize;
        return Json(new{result = "Redirect", url = Url.Action("List", "Product", new {pageSize = Convert.ToInt32(pageSize), CategoryName = plvm.CategoryName})});
            //return Json(new {result = "Redirect", url = Url.Action("List", "Product", new { pageSize = Convert.ToInt32(pageSize) }}}))};
            //return RedirectToActionPermanent("List", new {pageSize = Convert.ToInt32(pageSize)});
        }
        [HttpPost]
        public JsonResult ChangePageSorts(ProductListViewModel plvm)
        {
            var pageSort = plvm.PageSort;
            return Json(new { result = "Redirect", url = Url.Action("List", "Product", new { Sort = pageSort , CategoryName = plvm.CategoryName }) });
            //return Json(new {result = "Redirect", url = Url.Action("List", "Product", new { pageSize = Convert.ToInt32(pageSize) }}}))};
            //return RedirectToActionPermanent("List", new {pageSize = Convert.ToInt32(pageSize)});
        }
        public ViewResult List(string CategoryName = "Products", string Sort = "Name", int page = 1, int pageSize = 3)
        {

            ProductListViewModel model = new ProductListViewModel();
            switch (Sort)
            {
                case "Name":
                    model.Products = repository.Products
                        .OrderBy(product => product.Title)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                    break;
                case "Price":
                    model.Products = repository.Products
                        .OrderBy(product => product.Price)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                    break;
                default:
                    model.Products = repository.Products
                        .OrderBy(product => product.Title)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                    break;
            }
 
            model.PagingInfo = new Catalog
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = repository.Products.Count()
            };
            model.PageSizeList = new SelectList(new int[] {2, 3, 4});
            model.PageSortList = new SelectList(new string[] {"Name", "Price"});
            model.PageSize = pageSize.ToString();
            model.PageSort = Sort;
            model.CategoryName = CategoryName;
            model.RelatedProducts = repository.Products.Take(5);
            return View(model);
        }



        public ViewResult ConcreteProductPage(int Id)
        {
            ProductListViewModel model = new ProductListViewModel();
            model.product = repository.Products.Where(x => x.Id == Id).First();
            model.RelatedProducts = repository.Products
                .Where(x => x.Category == model.product.Category && x.Id != model.product.Id).Take(3);
            //Если тут будут ботинки и тд - делать свой размер, проверять сначала при получении айдишника
            model.SizeList = new SelectList(new string[] { "XS", "S", "M", "L", "XL" });
            //  
            return View(model);
        }


        public FileContentResult GetImage(int gameId)
        {
            Product game = repository.Products
                .FirstOrDefault(g => g.Id == gameId);

            if (game != null)
            {
                return File(game.Image, "image/jpg");
            }
            else
            {
                return null;
            }
        }
    }
}