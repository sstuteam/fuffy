using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PL_MVC.Models;
using System.IO;

namespace PL_MVC.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult NewAlbum()
        {
            ViewBag.Prf = AuthHelper.GetUser(HttpContext).Preference;
            return View("~/Views/Create/NewAlbum.cshtml");
        }
        [HttpGet]
        public ActionResult Add(Album model)
        {
            ViewBag.Prf = AuthHelper.GetUser(HttpContext).Preference;
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
            ViewBag.Prf = AuthHelper.GetUser(HttpContext).Preference;
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
                else
                {
                    byte[] image;
                    using (FileStream fstream = System.IO.File.OpenRead(AppDomain.CurrentDomain.BaseDirectory+ "Content/Photo/camera.png"))
                    {
                        image = new byte[fstream.Length];
                        fstream.Read(image, 0, image.Length);
                        
                    
                        heh.photo = new Photo()
                        {
                            Category = "Album",
                            IDAlbum=heh.IdAlbum,
                            Spetification="",
                            Date=DateTime.Now,
                            CountLikes=0,
                            IDPhoto=Guid.NewGuid(),
                            ImageType="img/jpeg",
                            Name="",
                            Image=image
                        };
                        heh.photo.Category = "Album";
                        Binder.Add(heh.photo);
                            }
                    viy.Add(heh);
                }
                //
            }
            IEnumerable<ProfileView> Terror = viy;
            //if (viy.Count != 0)
            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView("~/Views/Album/Terror.cshtml", Terror);
            //}
            /*else*/ return PartialView("~/Views/Album/Terror.cshtml", Terror);
            //else { return PartialView("~/Views/Album/Terror.cshtml",albums); }
        }
        public ActionResult  GetAlbumPhoto(Guid idAlbum)
        {
            ViewBag.Prf = AuthHelper.GetUser(HttpContext).Preference;
            Photo InReturn;
            if (Binder.GetAlbumPhoto(idAlbum) != null)
            {
                InReturn = Binder.GetAlbumPhoto(idAlbum);
                return File(InReturn.Image, "image/jpeg");
            }
            else
            {
                InReturn = null;
                return null;
            }
        }
        public PartialViewResult GetAlbumView(Guid idAlbum) //это неправильно
        {
            ViewBag.Prf = AuthHelper.GetUser(HttpContext).Preference;
            IEnumerable<Photo> photos = Binder.GetAllPhotoForAlbum(idAlbum);/*.FirstOrDefault(i => i.IDAlbum == idAlbum);*/
            ViewBag.AlbumName = Binder.GetAlbumName(idAlbum).Name;
            if (photos != null) 
            {
                return PartialView(photos);
            }
            else return PartialView(Binder.GetAllPhoto());
        }

    }
}