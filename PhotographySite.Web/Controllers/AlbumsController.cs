using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Photography.Core.Models;
using PhotographySite.Models;
using Photography.Core.Contracts.Service;

namespace PhotographySite.Controllers
{   
    public class AlbumsController : Controller
    {
        private readonly IAlbumService _albumService;
        
        public AlbumsController(IAlbumService albumService)
        {
            this._albumService = albumService;
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
            return View();
        } 

        //
        // POST: /Albums/Create

        [HttpPost]
        public ActionResult Create(Album album)
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