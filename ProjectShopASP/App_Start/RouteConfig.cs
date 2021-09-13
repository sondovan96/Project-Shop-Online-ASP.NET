using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectShopASP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Product Category",
                url: "fashion-male/{link}-{cateID}",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "ProjectShopASP.Controllers" }
            );
            routes.MapRoute(
                name: "Show All Product",
                url: "shop",
                defaults: new { controller = "Product", action = "ShowAllProduct", id = UrlParameter.Optional },
                namespaces: new[] { "ProjectShopASP.Controllers" }
            );
            routes.MapRoute(
                name: "Detail Product",
                url: "detail/{meta_title}-{idProduct}",
                defaults: new { controller = "Product", action = "DetailProduct", id = UrlParameter.Optional },
                namespaces: new[] { "ProjectShopASP.Controllers" }
            );
            routes.MapRoute(
         name: "Cart",
         url: "cart",
         defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
         namespaces: new[] { "ProjectShopASP.Controllers" }
     );
            routes.MapRoute(
            name: "Add Cart",
            url: "addcart",
            defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
            namespaces: new[] { "ProjectShopASP.Controllers" }
        );
            routes.MapRoute(
           name: "Check Out",
           url: "checkout",
           defaults: new { controller = "Cart", action = "Checkout", id = UrlParameter.Optional },
           namespaces: new[] { "ProjectShopASP.Controllers" }
       );
            routes.MapRoute(
          name: "Success",
          url: "success",
          defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
          namespaces: new[] { "ProjectShopASP.Controllers" }
      );
            routes.MapRoute(
          name: "Error",
          url: "error",
          defaults: new { controller = "Cart", action = "Error", id = UrlParameter.Optional },
          namespaces: new[] { "ProjectShopASP.Controllers" }
      );
            routes.MapRoute(
          name: "Search",
          url: "search",
          defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
          namespaces: new[] { "ProjectShopASP.Controllers" }
      );
            //      routes.MapRoute(
            //    name: "Edit Cate",
            //    url: "admin/{controller}/{action}/{id}",
            //    defaults: new { controller = "Category", action = "Edit", id = UrlParameter.Optional },
            //    namespaces: new[] { "ProjectShopASP.Controllers" }
            //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ProjectShopASP.Controllers" }
            );

            
        }
    }
}
