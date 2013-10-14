using Photography.Core.Contracts.Service;
using Photography.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotographySite.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            this._albumService = albumService;
        }
        
        public ActionResult Index()
        {
            return View(_albumService.GetAlbums());
        }

    }
}
