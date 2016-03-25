using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PL_MVC.Models;

namespace PL_MVC.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult NewAlbum()
        {
            return View("~/Views/Create/NewAlbum.cshtml");
        }
        [HttpGet]
        public ActionResult Add(Album model)
        {
            Binder.AddAlbum(model);
            //return View("~/Views/Create/NewAlbum.cshtml");
            return RedirectToAction("Profile","User");
        }
    }
}