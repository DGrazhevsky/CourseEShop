using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WineS.Models;
using WineS.Models.Entities;

namespace WineS.Controllers
{
    public class UserController : Controller
    {
    
        private AppUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
        }
        public ViewResult UserAccount()
        {
            return View(new UserProfile());
        }

        [HttpPost]
        public RedirectToRouteResult UserAccount(UserProfile userProfile)
        {
            var user = (User)UserManager.FindById(HttpContext.User.Identity.GetUserId());
            user.Email = userProfile.Email;

            user.UserName = userProfile.Email; ;
            user.FirstName = userProfile.FirstName;
            user.LastName = userProfile.LastName;
            UserManager.Update(user);
            return RedirectToAction("Main", "Main");
        }
    }
}