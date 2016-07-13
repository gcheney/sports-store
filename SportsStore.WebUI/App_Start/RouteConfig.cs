using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            #region Home Routes
            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new 
                { 
                    controller = "Home", 
                    action = "Index",                                 
                    category = (string)null, 
                    page = 1
                }
            );
            #endregion

            #region Product Routes
            routes.MapRoute(
                name: "Products",
                url: "Products",
                defaults: new
                {
                    controller = "Product",
                    action = "List",
                    category = (string)null,
                    page = 1
                }
            );

            routes.MapRoute(
                name: null,
                url: "Products/Page/{page}",
                defaults: new 
                {
                    controller = "Product",
                    action = "List",
                    category = (string)null,
                },
                constraints: new { page = @"\d+"} 
            );

            routes.MapRoute(
                name: null,
                url: "Products/{category}",
                defaults: new { controller = "Product", action = "List", page = 1 }
            );

            routes.MapRoute(
                name: null,
                url: "Products/{category}/Page/{page}",
                defaults: new { controller = "Product", action = "List" },
                constraints: new { page = @"\d+" } 
            );

            routes.MapRoute(
                name: "Details",
                url: "Product/Details/{productId}",
                defaults: new { controller = "Product", action = "Details" }
            );

            routes.MapRoute(
                name: "Image",
                url: "Product/Details/ViewImage/{productId}",
                defaults: new { controller = "Product", action = "ViewImage" }
            );
            #endregion

            #region Admin Routes
            routes.MapRoute(
                name: "Admin",
                url: "Admin",
                defaults: new { controller = "Admin", action = "Index" }
            );

            routes.MapRoute(
                name: "AdminEdit",
                url: "Admin/Edit/{productId}",
                defaults: new { controller = "Admin", action = "Edit"}
            );
            #endregion

            #region Cart Routes
            routes.MapRoute(
                name: "Cart",
                url: "Cart",
                defaults: new { controller = "Cart", action = "Index" }
            );
            #endregion

            #region Default Route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { 
                    controller = "Home", 
                    action = "Index", 
                    id = UrlParameter.Optional 
                }
            );
            #endregion
        }
    }
}
