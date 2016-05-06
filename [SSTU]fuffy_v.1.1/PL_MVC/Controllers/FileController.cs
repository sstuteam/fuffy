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
        [Authorize]
        [HttpPost]
        //[PageAuthorize(RoleID = 0)]
        //[PageAuthorize(RoleID = 2)]
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
                //return File(image.Image, uploaded.ContentType);                
            }
            return RedirectToAction("Profile", "User", user);
        }
        [Authorize]
        [HttpGet]
        //[PageAuthorize(RoleID = 0)]
        //[PageAuthorize(RoleID = 2)]
        public ActionResult Upload()
        {
            User user = AuthHelper.GetUser(HttpContext);
            if (user.RoleId != 3)
            {
                return View(user);
            }
            else return null;
        }

        //<a href=/File/GetPhoto/4234324>
        
        [HttpGet]
        public FileResult GetPhoto(Guid idPhoto)
        {
            //if (idPhoto == null)
            //    return null;
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
        public PartialViewResult PartialPhoto(Guid id)
        {
            var photoes = Binder.GetAllPhotoForUser(id);
            IEnumerable<Photo> sortedPhotoes = photoes.OrderBy(photo => photo.Data).Reverse();
            return PartialView(sortedPhotoes);
        }
        [HttpGet]
        public ViewResult GetPhotoView(Guid idPhoto)
        {
            Photo photo = Binder.GetAllPhoto().FirstOrDefault(i => i.IDPhoto == idPhoto);
            ViewBag.AlbumName = Binder.GetAlbumName(photo.IDAlbum).Name;
            ViewBag.CountLikes=Binder.GetLikes(idPhoto);
            ViewBag.UserId = AuthHelper.GetUser(HttpContext).idUser;
            ViewBag.UserIdFromAlbum = Binder.GetAlbumName(photo.IDAlbum).IDUser;
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
        [HttpGet]
        [PageAuthorize(RoleID = 2)]
        //[PageAuthorize(RoleID = 0)]
        public ActionResult EditPhoto(Guid photoId)
        {
            Photo photo = Binder.GetAllPhoto().FirstOrDefault(x => x.IDPhoto == photoId);
            return View(photo);
        }
        [HttpPost]
        //[PageAuthorize(RoleID = 2)]
        [PageAuthorize(RoleID = 0)]
        public ActionResult EditComment(Photo photo)
        {
            Binder.EditPhoto(photo);
            Guid idPhoto = photo.IDPhoto;
            return RedirectToAction("GetPhotoView", "File", new { idPhoto });
        }
    }
}