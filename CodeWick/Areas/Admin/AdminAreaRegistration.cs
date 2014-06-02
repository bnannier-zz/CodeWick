using System.Web.Mvc;

namespace CodeWick.Areas.Admin {
    public class AdminAreaRegistration : AreaRegistration {
        public override string AreaName {
            get {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "CodeWick.Areas.Admin.Controllers", "CodeWick.Controllers" }
            );

            context.MapRoute(
                "Admin_Parameters_2",
                "Admin/{controller}/{action}/{id}/{id0}",
                new { action = "Index", id = UrlParameter.Optional, id0 = UrlParameter.Optional },
                new[] { "CodeWick.Areas.Admin.Controllers", "CodeWick.Controllers" }
            );
        }
    }
}