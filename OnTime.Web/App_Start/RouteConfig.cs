using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnTime.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "", 
                url: "index", 
                defaults: new {controller = "Default", action = "Index"});

            // /diag1,/diag2,/diag3 => /diag
            for (int i = 1; i < 4; i++)
            {
                routes.MapRoute("RouteName" + i, "diag" + i, new {controller = "Default", action = "DiagnosisStock"});
            }
            routes.MapRoute(
                name: "",
                url: "diag",
                defaults: new {controller="Default",action= "DiagnosisStock" }
            );
            routes.MapRoute(
                name: "", 
                url: "qq", 
                defaults: new { controller = "Default", action = "JoinQQ" }
                );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
