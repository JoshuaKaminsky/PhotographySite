using System.Web.Mvc;
using Photography.Core.Contracts.Service;
using Photography.Core.Models;

namespace PhotographySite.Controllers
{   
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

        public ViewResult Details(int id)
        {
            return View(_userService.GetUser(id));
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
                _userService.CreateUser(user.Name, user.EmailAddress);
                
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

        public ActionResult Delete(int id)
        {
            return View(_userService.GetUser(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _userService.DeleteUser(id);

            return RedirectToAction("Index");
        }
    }
}