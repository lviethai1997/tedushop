using System.Web.Mvc;
using System.Web.Routing;

namespace TeduShop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "About",
            url: "gioi-thieu.html",
             namespaces: new string[] { "TeduShop.Web.Controllers" },
            defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional }
        );

            routes.MapRoute(
              name: "Login",
              url: "dang-nhap.html",
                namespaces: new string[] { "TeduShop.Web.Controllers" },
              defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
          );

            routes.MapRoute(
            name: "Sign Up",
            url: "dang-ky.html",
              namespaces: new string[] { "TeduShop.Web.Controllers" },
            defaults: new { controller = "SignUp", action = "Index", id = UrlParameter.Optional }
        );

            routes.MapRoute(
             name: "Cart",
             url: "gio-hang.html",
               namespaces: new string[] { "TeduShop.Web.Controllers" },
             defaults: new { controller = "Cart", action = "index", id = UrlParameter.Optional }
         );

            routes.MapRoute(
               name: "Product in Category",
               url: "{alias}.pc-{id}.html",
                 namespaces: new string[] { "TeduShop.Web.Controllers" },
               defaults: new { controller = "Product", action = "ProductInCategory", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Product Detail",
              url: "{alias}.p-{id}.html",
                namespaces: new string[] { "TeduShop.Web.Controllers" },
              defaults: new { controller = "Product", action = "GetProductDetail", id = UrlParameter.Optional }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                  namespaces: new string[] { "TeduShop.Web.Controllers" },
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}