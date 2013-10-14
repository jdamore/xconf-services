using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace mvc_iis
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Voucher",
                url: "{controller}/{storeNumber}",
                defaults: new { controller = "Voucher", action = "Index", storeNumber = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "VoucherJson",
                url: "{controller}/json/{storeNumber}",
                defaults: new { controller = "Voucher", action = "Json", storeNumber = UrlParameter.Optional }
            );
        }
    }
}