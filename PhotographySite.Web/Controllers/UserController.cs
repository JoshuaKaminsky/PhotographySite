using Photography.Core.Contracts.Service;
using System.Web.Mvc;

namespace PhotographySite.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
    }
}
