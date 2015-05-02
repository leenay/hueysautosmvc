using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HueysAutosMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "VehicleCreate",
                url: "Vehicles/Create",
                defaults: new { Controller = "Vehicles", action = "Create" }

            );

            routes.MapRoute(
                name: "VehicleEdit",
                url: "Vehicles/Edit",
                defaults: new { Controller = "Vehicles", action = "Edit" }

            );

            routes.MapRoute(
                name: "VehicleDelete",
                url: "Vehicles/Delete",
                defaults: new { Controller = "Vehicles", action = "Delete" }

            );

            routes.MapRoute(
                name: "VehicleGetAjax",
                url: "Vehicles/GetModels",
                defaults: new { Controller = "Vehicles", action = "GetModels" }

            );

            routes.MapRoute(
                name: "VehicleDetails",
                url: "Vehicles/Details/{id}",
                defaults: new { Controller = "Vehicles", action = "Details" }

            );


            routes.MapRoute(
                name: "ManufacturerFilter",
                url: "Vehicles/{manufacturer}/{vmodel}",
                defaults: new { Controller = "Vehicles", action = "Index", manufacturer = UrlParameter.Optional, vmodel = UrlParameter.Optional}

            );

            routes.MapRoute(
                name: "VehicleIndex",
                url: "Vehicles",
                defaults: new { Controller = "Vehicles", action = "Index" }

            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}
