using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MvcApp_csom_irib_01
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultIRIBset",
                routeTemplate: "irib/{controller}/{user}/{password}/{id}/{id1}/{id2}",
                defaults: new { user = RouteParameter.Optional, password = RouteParameter.Optional, id = RouteParameter.Optional, id1 = RouteParameter.Optional, id2 = RouteParameter.Optional }
            );


            config.Routes.MapHttpRoute(
                name: "DefaultIRIBget",
                routeTemplate: "irib/{controller}/{user}/{password}/{id}/",
                defaults: new { user = RouteParameter.Optional, password = RouteParameter.Optional, id = RouteParameter.Optional }
            );

        }
    }
}
