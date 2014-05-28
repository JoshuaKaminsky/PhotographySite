using System.Web.Mvc;
using Photography.Core.Models;
using Photography.Core.Contracts.Service;
using System.Linq;
using PhotographySite.Models;
using System;

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
            return View(new AlbumModel { Album = new Album(), AvailableCategories = _categoryService.GetCategories().ToList() });
        } 

        //
        // POST: /Albums/Create

        [HttpPost]
        public ActionResult Create(AlbumModel model)
        {
            if (ModelState.IsValid)
            {
                _albumService.CreateAlbum(model.Album.Name, model.Album.Description, model.Album.IsPublic, model.Album.Tags, model.SelectedCategoryId.Value);
                return RedirectToAction("Index");  
            }

            return View(model);
        }
        
        //
        // GET: /Albums/Edit/5
 
        public ActionResult Edit(int id)
        {
            var album = _albumService.GetAlbum(id);

            return View(new AlbumModel
            {
                Album = album,
                AvailableCategories = _categoryService.GetCategories().ToList(),
                SelectedCategoryId = album.Category != null ? new Nullable<int>(album.Category.Id) : null
            });
        }

        //
        // POST: /Albums/Edit/5

        [HttpPost]
        public ActionResult Edit(AlbumModel model)
        {
            if (ModelState.IsValid)
            {
                _albumService.UpdateAlbum(model.Album.Id, model.Album.Name, model.Album.Description, model.Album.IsPublic, model.Album.Tags);
                return RedirectToAction("Index");
            }
            return View(model);
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