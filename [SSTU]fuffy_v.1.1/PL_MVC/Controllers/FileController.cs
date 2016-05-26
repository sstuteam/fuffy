﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PL_MVC.Models;
using System.IO;

namespace PL_MVC.Controllers
{
    public class FileController : Controller
    {
        [Authorize]
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase uploaded,string AlbumName, string Title, string spetification,string Category)
        {           
            var user = AuthHelper.GetUser(HttpContext);
            if (uploaded != null)
            {
                Photo image = new Photo()
                {
                    IDPhoto = Guid.NewGuid(),
                    Name = Title,
                    Spetification = spetification,
                    CountLikes = 0,//не пишет в дб                    
                    Image = new byte[uploaded.ContentLength],
                    ImageType = uploaded.ContentType,
                    Category=Category,//добавил поле категория
                };
                if (image.Spetification == null)
                {
                    image.Spetification = "";
                }
                if (AlbumName != null)
                {
                    image.IDAlbum = Binder.GetIdAlbum(user.idUser, AlbumName);//берет имменно такой альбом
                }
                else
                {
                    image.IDAlbum = Binder.GetIdAlbum(user.idUser, "Other");
                }
                using (BinaryReader br = new BinaryReader(uploaded.InputStream))
                {
                    image.Image = br.ReadBytes(image.Image.Length);
                }
                if (user.RoleId != 3)
                {
                    Binder.Add(image);
                }             
            }
            return RedirectToAction("Profile", "User", user);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Upload()
        {
            User user = AuthHelper.GetUser(HttpContext);
            ViewBag.Prf = AuthHelper.GetUser(HttpContext).Preference;
            if (user.RoleId != 3)
            {
                return View(user);
            }
            else return View(user);
        }

        //<a href=/File/GetPhoto/4234324>
        
        [HttpGet]
        public FileResult GetPhoto(Guid idPhoto)
        {
            Photo photo = Binder.GetPhoto(idPhoto);

            if (photo != null)
            {
                return File(photo.Image, "image/jpeg"); 
            }
            else
            {
                return null;
            }
        }
        public FileResult GetAvatar(Guid idUser)
        {
            User user = Binder.GetUser(idUser);
            if (user.Avatar != null)
            {
                return File(user.Avatar, "image/jpeg");
            }
            else
            {
                return null;
            }
        }
        [HttpGet]
        public ActionResult EditAvatar()
        {
            ViewBag.Prf = AuthHelper.GetUser(HttpContext).Preference;
            ViewBag.UserId = AuthHelper.GetUser(HttpContext);
            return View();
        }
        public ActionResult EditAvatar(HttpPostedFileBase uploaded)
        {
            var user = AuthHelper.GetUser(HttpContext);
            if (uploaded != null)
            {
                Photo image = new Photo()
                {
                    IDPhoto = Guid.NewGuid(),
                    Name = "",
                    Spetification = "",
                    CountLikes = 0,              
                    Image = new byte[uploaded.ContentLength],
                    ImageType = uploaded.ContentType,
                    Category = "",//добавил поле категория
                    IDAlbum = Guid.NewGuid()
                };
                using (BinaryReader br = new BinaryReader(uploaded.InputStream))
                {
                    image.Image = br.ReadBytes(image.Image.Length);
                }
                if (user.RoleId != 3)
                {
                    Binder.EditAvatar(user.idUser, image);
                }               
            }
            return RedirectToAction("Profile", "User", user);
        }
        [HttpGet]
        public PartialViewResult PartialPhoto(Guid id)
        {
            ViewBag.Prf = AuthHelper.GetUser(HttpContext).Preference;
            return PartialView(Binder.GetAllPhotoForUser(id).Where(photo=>photo.Category!="Album").OrderBy(photo => photo.Date).Reverse());
        }
        [HttpGet]
        public ViewResult GetPhotoView(Guid idPhoto)
        {
            Photo photo = Binder.GetAllPhoto().FirstOrDefault(i => i.IDPhoto == idPhoto);
                        
            ViewBag.Prf = Binder.GetUser(Binder.GetAlbumName(photo.IDAlbum).IDUser).Preference;
            ViewBag.AlbumName = Binder.GetAlbumName(photo.IDAlbum).Name;
            ViewBag.CountLikes=Binder.GetLikes(idPhoto);
            ViewBag.UserId = AuthHelper.GetUser(HttpContext).idUser;
            ViewBag.UserIdFromAlbum = Binder.GetAlbumName(photo.IDAlbum).IDUser;
            ViewBag.UserName= Binder.GetUser(Binder.GetAlbumName(photo.IDAlbum).IDUser).Name;

            if (photo != null)
            {
                return View(photo);
            }
            else
            {
                return null;
            }
        }
        [Authorize]
        public ActionResult DeletePhoto(Guid idPhoto)
        {
            if (Binder.DeletePhoto(idPhoto))
            {
                return RedirectToAction("Profile", "User");
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public ActionResult EditPhoto(Photo photo)
        {
            ViewBag.Prf = AuthHelper.GetUser(HttpContext).Preference;
            if (photo.Spetification == null)
            {
                photo.Spetification = "";
            }
            Binder.EditPhoto(photo);
            Guid idPhoto = photo.IDPhoto;
            return RedirectToAction("GetPhotoView", "File", new { idPhoto });
        }
        [HttpGet]
        public ActionResult EditPhoto(Guid idPhoto)
        {
            ViewBag.Prf = AuthHelper.GetUser(HttpContext).Preference;
            Photo photo = Binder.GetAllPhoto().FirstOrDefault(x => x.IDPhoto == idPhoto);
            return View(photo);
        }

    }
}