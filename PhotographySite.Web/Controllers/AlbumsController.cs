using System.Web.Mvc;
using Photography.Core.Models;
using Photography.Core.Contracts.Service;
using System.Linq;
using PhotographySite.Models;

namespace PhotographySite.Controllers
{   
    public class AlbumsController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly ICategoryService _categoryService;
        
        public AlbumsController(IAlbumService albumService, ICategoryService categoryService)
        {
            this._albumService = albumService;
            this._categoryService = categoryService;
        }

        //
        // GET: /Albums/

        public ViewResult Index()
        {
            return View(_albumService.GetAlbums());
        }

        //
        // GET: /Albums/Details/5

        public ViewResult Details(int id)
        {
            Album album = _albumService.GetAlbum(id);
            return View(album);
        }

        //
        // GET: /Albums/Create

        public ActionResult Create()
        {
            var categories = _categoryService.GetCategories();
            return View(new AlbumModel { AvailableCategories = categories.ToList() });
        } 

        //
        // POST: /Albums/Create

        [HttpPost]
        public ActionResult Create(AlbumModel album)
        {
            if (ModelState.IsValid)
            {
                _albumService.CreateAlbum(album.Name, album.Description, album.IsPublic, album.Tags);
                return RedirectToAction("Index");  
            }

            return View(album);
        }
        
        //
        // GET: /Albums/Edit/5
 
        public ActionResult Edit(int id)
        {
            Album album = _albumService.GetAlbum(id);
            return View(album);
        }

        //
        // POST: /Albums/Edit/5

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                _albumService.UpdateAlbum(album.Id, album.Name, album.Description, album.IsPublic, album.Tags);
                return RedirectToAction("Index");
            }
            return View(album);
        }

        //
        // GET: /Albums/Delete/5
 
        public ActionResult Delete(int id)
        {
            Album album = _albumService.GetAlbum(id);;
            return View(album);
        }

        //
        // POST: /Albums/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            bool deleteSuccessful = _albumService.DeleteAlbum(id);
            return RedirectToAction("Index");
        }
    }
}