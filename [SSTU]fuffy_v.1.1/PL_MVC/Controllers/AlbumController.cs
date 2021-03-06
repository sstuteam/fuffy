﻿using System;
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
            var albums = Binder.GetAllAlbums(id);//исправил
            List<ProfileView> viy = new List<ProfileView>(0);
            for (int i = 0; i < albums.Count(); i++)
            {
                ProfileView heh = new ProfileView();
               heh.name= albums.ElementAt(i).Name;
                heh.IdAlbum = albums.ElementAt(i).IDAlbum;
                if (Binder.GetAlbumPhoto(albums.ElementAt(i).IDAlbum) != null)
                {
                    heh.photo = Binder.GetAlbumPhoto(albums.ElementAt(i).IDAlbum);
                    viy.Add(heh);
                }
                else { }
                //viy.Add(heh);
            }
            IEnumerable<ProfileView> Terror = viy;
            //if (viy.Count != 0)
            return PartialView("~/Views/Album/Terror.cshtml",Terror);
            //else { return PartialView("~/Views/Album/Terror.cshtml",albums); }
        }
        public ActionResult  GetAlbumPhoto(Guid idAlbum)
        {
            Photo InReturn;
            if (Binder.GetAlbumPhoto(idAlbum) != null)
            {
                InReturn = Binder.GetAlbumPhoto(idAlbum); return File(InReturn.Image, "image/jpeg");
            }
            else
            {
                InReturn = null;
                return null;
            }
        }
        public ActionResult GetAlbumView(Guid idAlbum) //это неправильно
        {
           IEnumerable<Photo> photos = Binder.GetAllPhotoForAlbum(idAlbum);/*.FirstOrDefault(i => i.IDAlbum == idAlbum);*/
            if (photos != null) 
            {
                return RedirectToAction("Profile", "User", photos);
            }
            else return RedirectToAction("Profile", "User");
        }

    }
}