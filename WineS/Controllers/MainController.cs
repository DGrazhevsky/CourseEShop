using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineS.Models.Repositories;
using WineS.ViewModels;

namespace WineS.Controllers
{
    public class MainController : Controller
    {
        private IProductRepository repository;
        private IOrderRepository orderProcessor;
        public MainController(IProductRepository repo, IOrderRepository processor)
        {
            repository = repo;
            orderProcessor = processor;
        }
        public ViewResult Main()
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products
            };
            return View(model);
        }
    }
}