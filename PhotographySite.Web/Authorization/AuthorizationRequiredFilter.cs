using System;
using System.Web.Mvc;
using Photography.Core.Contracts.Service;

namespace PhotographySite.Authorization
{
    public class AuthorizationRequiredFilter : IAuthorizationFilter
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly ISessionService _sessionService;

        public AuthorizationRequiredFilter(IUserService userService, IRoleService roleService, ISessionService sessionService)
        {
            _userService = userService;
            _roleService = roleService;
            _sessionService = sessionService;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //pull the authentication information off the header and see if the user is logged in
            //filterContext.HttpContext.Request.Headers
            int userId;
            Guid sessionId;

            if (!ParseHeader(filterContext, out userId, out sessionId))
            {
                //redirect to the login page
            }
            else
            {
                //validate information
                if (!_sessionService.ValidateSession(userId, sessionId))
                {
                    //redirect to login page
                }
                else
                {
                    //set the current user
                }
            }

        }

        private bool ParseHeader(AuthorizationContext filterContext, out int userId, out Guid sessionId)
        {
            userId = -1;
            sessionId = Guid.NewGuid();

            return true;
        }
    }
}