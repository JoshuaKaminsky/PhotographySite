using System.Web.Mvc;

namespace PhotographySite.Authorization
{
    public class AuthorizationRequiredAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
        }

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            return true;
        }
    }
}