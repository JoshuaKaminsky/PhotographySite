using System.Web.Mvc;
using Photography.Core.Contracts.Service;
using Photography.Core.Models;
using PhotographySite.Authorization;

namespace PhotographySite.Controllers
{
    [AuthorizationRequired(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public ViewResult Index()
        {
            return View(_userService.GetUsers());
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.CreateUser(user.Name, user.EmailAddress, user.Discount);
                
                return RedirectToAction("Index");  
            }

            return View(user);
        }
        
        public ActionResult Edit(int id)
        {
            return View(_userService.GetUser(id));
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(user);

                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost]
        public bool ResetPassword(int id)
        {
            return _userService.ResetPasswordRequest(id);
        }

        [HttpPost]
        public bool Delete(int id)
        {
            return _userService.DeleteUser(id);
        }
    }
}