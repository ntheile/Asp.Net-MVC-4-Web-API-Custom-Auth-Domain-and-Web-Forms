using System.Web;
using System.Web.Mvc;

namespace AspNet_MVC_Web_API_Custom_Auth_Domain_Forms
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}