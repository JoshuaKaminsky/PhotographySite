using System.Web.Mvc;

namespace PhotographySite.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

    }
}
