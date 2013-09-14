using System.Web.Mvc;

namespace PhotographySite.Controllers
{
    using System.Security.Authentication;
    using System.Web.Security;

    using Photography.Core.Contracts.Service;

    using PhotographySite.Models;

    public class AccountController : Controller
    {
        private readonly ISessionService _sessionService;

        private readonly IUserService _userService;

        public AccountController(ISessionService sessionService, IUserService userService)
        {
            this._sessionService = sessionService;
            this._userService = userService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account model)
        {
            if (!_userService.ValidateUser(model.EmaiAddress, model.Password))
            {
                throw new AuthenticationException();
            }

            var user = _userService.GetUserByEmailAddress(model.EmaiAddress);
            if (user == null)
            {
                throw new AuthenticationException();
            }

            var session = _sessionService.CreateSession(user.Id);

            return new RedirectResult("Home/Index");
        }
    }
}
