using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WineS.IoC;
using WineS.Models;
using WineS.Models.Entities;
using WineS.ViewModels;

namespace WineS.Controllers
{
    public class AccountController : Controller
    {

        private AppUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
        }

        public ActionResult Previous()
        {
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName
                };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    claim.AddClaim(new Claim("FirstName", user.FirstName));
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Main","Main");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }

            return View(model);
        }


        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        public ActionResult Login()
        {
            var returnUrl = Request.UrlReferrer;
            //if (fromCart == true)
            //    ViewBag.fromCart = true;
            //else
            //    ViewBag.fromCart = false;
            ViewBag.returnUrl = returnUrl.ToString();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = await UserManager.FindAsync(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    claim.AddClaim(new Claim("FirstName", user.FirstName));
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    if (String.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Main", "Main");
                    return Redirect(returnUrl);
                }
            }

            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        public ActionResult Logout(Cart cart)
        {

            AuthenticationManager.SignOut();
            cart.Clear();
            var returnUrl = Request.UrlReferrer;
            return Redirect(returnUrl.ToString());
        }
    }
    //IAuthProvider authProvider;
    //public AccountController(IAuthProvider auth)
    //{
    //    authProvider = auth;
    //}

    //public ViewResult Login()
    //{
    //    return View();
    //}

    //[HttpPost]
    //public ActionResult Login(LoginViewModel model, string returnUrl)
    //{

    //    if (ModelState.IsValid)
    //    {
    //        if (authProvider.Authenticate(model.UserName, model.Password))
    //        {
    //            return Redirect(returnUrl ?? Url.Action("Wines", "Admin"));
    //        }
    //        else
    //        {
    //            ModelState.AddModelError("", "Неправильный логин или пароль");
    //            return View();
    //        }
    //    }
    //    else
    //    {
    //        return View();
    //    }
    //}
}
