using System;
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
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase uploaded,string AlbumName, string Title, string spetification)
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
                    ImageType = uploaded.ContentType
                };
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
                Binder.Add(image);
                //return File(image.Image, uploaded.ContentType);                
            }
            return RedirectToAction("Profile", "User", user);
        }
        [HttpGet]
        public ActionResult Upload()
        {
            User user = AuthHelper.GetUser(HttpContext);
            return View(user);
        }

        //<a href=/File/GetPhoto/4234324>
        
        [HttpGet]
        public FileResult GetPhoto(Guid idPhoto)
        {
            Photo photo = Binder.GetAllPhoto().FirstOrDefault(i => i.IDPhoto == idPhoto);
            if (photo != null)
            {
                return File(photo.Image, "image/jpeg"); 
            }
            else
            {
                return null;
            }
        }
        [HttpGet]
        public ViewResult GetPhotoView(Guid idPhoto)
        {
            Photo photo = Binder.GetAllPhoto().FirstOrDefault(i => i.IDPhoto == idPhoto);
            ViewBag.AlbumName = Binder.GetAlbumName(photo.IDAlbum).Name;
            if (photo != null)
            {
                return View(photo);
            }
            else
            {
                return null;
            }
        }

    }
}