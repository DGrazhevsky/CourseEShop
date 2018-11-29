using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WineS
{
    public class RouteConfig
    {
        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapRoute(null,
        //         "",
        //         new
        //         {
        //             controller = "Wine",
        //             action = "List",
        //             winecolor = (string)null,
        //             page = 1
        //         }
        //     );

        //    routes.MapRoute(
        //        name: null,
        //        url: "Page{page}",
        //        defaults: new { controller = "Wine", action = "List", winecolor = (string)null },
        //        constraints: new { page = @"\d+" }
        //    );

        //    //routes.MapRoute(null,
        //    //   "{winecolor}",
        //    //    new { controller = "Wine", action = "List", page = 1 }
        //    //);

        //    routes.MapRoute(null,
        //        "{winecolor}/Page{page}",
        //        new { controller = "Wine", action = "List" },
        //        new { page = @"\d+" }
        //    );

        //    routes.MapRoute(name: null,
        //        url: "Admin",
        //       defaults: new { controller = "Admin", action = "Wines" }

        //    );



        //    routes.MapRoute(null, "{controller}/{action}");
        //}


        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Main", action = "Main", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "Default1",
              url: "{controller}/{action}",
              defaults: new { controller = "Main", action = "Main", id = UrlParameter.Optional }
          );
        }
    }
}