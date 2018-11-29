using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using WineS.Models.Context;

namespace WineS.Models.Entities
{
    public class AppUserManager : UserManager<User>
    {
        public AppUserManager(IUserStore<User> store) : base(store) { }
        
      

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options,
                IOwinContext context)
            {
                ApplicationContext db = context.Get<ApplicationContext>();
                AppUserManager manager = new AppUserManager(new UserStore<User>(db));
                return manager;
            }
        }
    }
