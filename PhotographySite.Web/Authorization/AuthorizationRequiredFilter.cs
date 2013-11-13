using System;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using Photography.Core.Contracts.Service;
using PhotographySite.Models;

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
            int userId;
            Guid sessionId;

            //if (!ParseHeader(filterContext, out userId, out sessionId))
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}
            //else
            //{
            //    if (!_sessionService.ValidateSession(userId, sessionId))
            //    {
            //        FormsAuthentication.RedirectToLoginPage();
            //    }
            //    else
            //    {
            //        var user = _userService.GetUser(userId);
            //        var roles = _roleService.GetUserRoles(userId);

            //        //check that the roles match the attribute
            //    }
            //}

        }

        private static bool ParseHeader(ControllerContext context, out int userId, out Guid sessionId)
        {
            try
            {
                var authCookie = context.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                var session = JsonConvert.DeserializeObject<SessionModel>(authTicket.UserData);

                userId = session.UserId;
                sessionId = session.SessionKey;
            }
            catch 
            {
                userId = -1;
                sessionId = Guid.Empty;

                return false;
            }
            
            return true;
        }
    }
}