using System.Linq;
using System.Web.Mvc;
using Photography.Core.Contracts.Service;
using PhotographySite.Authorization;
using PhotographySite.Models;

namespace PhotographySite.Controllers
{
    [AuthorizationRequired(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UsersController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public ViewResult Index()
        {
            return View(_userService.GetUsers());
        }

        public ActionResult Create()
        {
            var roles = _roleService.GetRoles();

            return View(new UserModel {AvailableRoles = roles.ToList()});
        } 

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.CreateUser(model.User.Name, model.User.EmailAddress, model.User.Discount);

                _roleService.UpdateUserRoles(user.Id, model.UserRoleIds);

                return RedirectToAction("Index");  
            }

            return View(model);
        }
        
        public ActionResult Edit(int id)
        {
            var user = _userService.GetUser(id);
            var userRoles = _roleService.GetUserRoles(user.Id).Select(role => role.Id).ToList();
            var roles = _roleService.GetRoles().ToList();

            return View(new UserModel {User = user, UserRoleIds = userRoles, AvailableRoles = roles});
        }

        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.UpdateUser(model.User);

                _roleService.UpdateUserRoles(user.Id, model.UserRoleIds);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult ResetPassword(int id)
        {
            _userService.ResetPasswordRequest(id);
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Disable(int id)
        {
            var user = _userService.GetUser(id);

            user.IsActive = false;

             _userService.UpdateUser(user);
             
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Enable(int id)
        {
            var user = _userService.GetUser(id);

            user.IsActive = true;

            _userService.UpdateUser(user);
            
            return RedirectToAction("Index");
        }
    }
}