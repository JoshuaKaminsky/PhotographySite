using System.Web.Mvc;
using PhotographySite.Authorization;

namespace PhotographySite.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizationRequiredAttribute());
        }
    }
}