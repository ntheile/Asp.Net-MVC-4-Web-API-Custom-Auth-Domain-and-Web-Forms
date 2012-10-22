using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AspNet_MVC_Web_API_Custom_Auth_Domain_Forms
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
        }
    }
}
