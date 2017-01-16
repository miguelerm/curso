using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApp.App_Start
{
    public class RoutesConfig
    {
        public static void Configure(RouteCollection routes)
        {

            routes.MapMvcAttributeRoutes();

            routes.MapRoute("default", 
                "{controller}/{action}/{id}", 
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}