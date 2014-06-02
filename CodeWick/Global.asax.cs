using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;

using CodeWick.Helpers;
using CodeWick.Models;
using CodeWick.Migrations;

namespace CodeWick {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    [SessionAttribute]
    public class MvcApplication : System.Web.HttpApplication {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Site", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new[] { "CodeWick.Controllers" }
            );

            //routes.MapRoute(
            //    "Default_Area", // Route name
            //    "{area}/{controller}/{action}/{id}", // URL with parameters
            //    new { area = "Page", controller = "Main", action = "Index", id = UrlParameter.Optional },
            //    new[] { "CodeWick.Areas.Page.Controllers" }
            //);

        }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<CodeWickContext>(new MigrateDatabaseToLatestVersion<CodeWickContext, Configuration>());
        }
    }
}