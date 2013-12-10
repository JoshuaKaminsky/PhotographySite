using System.Collections.Generic;
using System.Web.Mvc;

namespace PhotographySite.Authorization
{
    public class FilterProvider : IFilterProvider
    {
        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var anonymousAction = actionDescriptor.GetCustomAttributes(typeof (AllowAnonymousAttribute), false);

            if (anonymousAction.Length == 0)
            {
                yield return new Filter(DependencyResolver.Current.GetService<AuthorizationRequiredFilter>(), FilterScope.Controller, 1);
            }
            else
            {
                yield return new Filter(new FilterAttributeFilterProvider(), FilterScope.Controller, 1);
            }
        }
    }
}