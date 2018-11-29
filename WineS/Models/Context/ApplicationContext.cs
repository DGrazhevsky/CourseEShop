using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using WineS.Models.Entities;

namespace WineS.Models.Context
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext() : base("EntityFContext") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}