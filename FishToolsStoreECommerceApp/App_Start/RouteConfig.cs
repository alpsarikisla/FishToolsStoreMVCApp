using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FishToolsStoreECommerceApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home_Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 new[] { "FishToolsStoreECommerceApp.Controllers" }
            );

            routes.MapRoute(
                name: "Login_Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional },
                new[] { "FishToolsStoreECommerceApp.Controllers" }
                );

            routes.MapRoute(
                name: "Member_Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Member", action = "Index", id = UrlParameter.Optional },
                new[] { "FishToolsStoreECommerceApp.Controllers" }
                );
        }
    }
}
