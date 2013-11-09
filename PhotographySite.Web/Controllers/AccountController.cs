using System.Security.Authentication;
using System.Web.Mvc;
using System.Web.Security;
using Photography.Core.Contracts.Service;
using PhotographySite.Authorization;
using PhotographySite.Models;

namespace PhotographySite.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISessionService _sessionService;

        private readonly IUserService _userService;

        public AccountController(ISessionService sessionService, IUserService userService)
        {
            _sessionService = sessionService;
            _userService = userService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account model)
        {
            if (!_userService.ValidateUser(model.EmailAddress, model.Password))
            {
                throw new AuthenticationException();
            }

            var user = _userService.GetUserByEmailAddress(model.EmailAddress);
            if (user == null)
            {
                throw new AuthenticationException();
            }

            var session = _sessionService.CreateSession(user.Id);

            var authCookie = FormsAuthentication.GetAuthCookie(user.Id.ToString(), false);

            authCookie.Values.Add(AuthenticationConstants.AuthenticationCookieUserId, user.Id.ToString());
            authCookie.Values.Add(AuthenticationConstants.AuthenticationCookieSessionId, session.SessionKey.ToString());

            HttpContext.Response.Cookies.Add(authCookie);

            return new RedirectResult("Home/Index");
        }
    }
}
