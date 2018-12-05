using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineS.Entities;
using WineS.Models;
using WineS.Models.Repositories;
using WineS.ViewModels;

namespace WineS.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private IOrderRepository orderProcessor;
        public CartController(IProductRepository repo, IOrderRepository processor)
        {
            repository = repo;
            orderProcessor = processor;
        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        //public ViewResult Checkout(Cart cart)
        //{
        //    if (cart.Lines.Count() == 0)
        //    {
        //        ModelState.AddModelError("", "Извините, ваша корзина пуста!");
        //    }
        //    return View(new ShippingInfo());
        //}



        public PartialViewResult AddToCart(Cart cart, int Id, string returnUrl, string Size = "Undefined")
        {
            Product product = repository.Products
                .FirstOrDefault(g => g.Id == Id);

            if (product != null)
            {
                cart.AddItem(product, 1, Size);
            }

            return PartialView(cart);
            //return RedirectToAction("Main", "Main");
        }
        [HttpPost]
        public ActionResult RemoveFromCart(Cart cart, int id)
        {
            Product product = repository.Products
                .FirstOrDefault(g => g.Id == id);
            if (cart.Lines == null)
            {
                return new JsonResult() { Data = new { Status = "ERROR" } };
            }
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return new JsonResult() { Data = new { Status = "SUCCESS" } };
        }

        public PartialViewResult SummaryPrice(Cart cart)
        {
            return PartialView(cart);
        }


        public RedirectToRouteResult Checkout(Cart cart)
        {

            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");

            }
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                
               
                   // orderProcessor.SendOrders(cart, shippingDetails);
                    //cart.Clear();
                    return RedirectToAction("OrderConfirm", "Cart");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

        public ViewResult OrderConfirm(Cart cart)
        {
            return View(new ShippingInfo());
        }

        [HttpPost]
        public RedirectToRouteResult OrderConfirm(Cart cart, ShippingInfo shippinginfo)
        {

            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");

            }
         

                orderProcessor.SendOrders(cart, shippinginfo);
                cart.Clear();
                return RedirectToAction("Completed", "Cart");
     

        }

        public ViewResult Completed()
        {
            return View();
        }
        //[HttpPost]
        //public ViewResult Checkout(Cart cart, ShippingInfo shippingDetails)
        //{
        //    if (cart.Lines.Count() == 0)
        //    {
        //        ModelState.AddModelError("", "Извините, ваша корзина пуста!");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        orderProcessor.SendOrders(cart, shippingDetails);
        //        cart.Clear();
        //        return View("Completed");
        //    }
        //    else
        //    {
        //        return View(shippingDetails);
        //    }
        //}
    }
}