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
            var user = AuthHelper.GetUser(HttpContext);
            model.IDUser = user.idUser;
            if (Binder.AddAlbum(model))
                //return View("~/Views/Create/NewAlbum.cshtml");
                return RedirectToAction("Profile", "User");
            else {
                // model.Name = "this name is already used";
                return RedirectToAction("NewAlbumBreak", "Album");
            }
        }
        [HttpGet]
        public ActionResult GetAlbum(Guid id) 
        {
            var albums = Binder.GetAllAlbums(id);
            return View(albums);
        }
        public ActionResult GetPhotoOfAlbum(Guid idAlbum) //это неправильно
        {
           IEnumerable<Photo> photoes = Binder.GetAllPhotoForAlbum(idAlbum);/*.FirstOrDefault(i => i.IDAlbum == idAlbum);*/
            if (photoes.Count()!=0) 
            {
                return View(photoes);
            }
            else return RedirectToAction("Profile", "User");
        }

    }
}