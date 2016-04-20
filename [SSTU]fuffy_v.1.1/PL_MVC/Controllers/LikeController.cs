using PL_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class LikeController : Controller
    {
        // GET: Like
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult GetLikes(Guid id) //это правильно
        {
            ViewBag.Likes=Binder.GetLikes(id);
            return PartialView();

        }
        [HttpGet]
        public PartialViewResult GetLikesForComment(Guid idComment)
        {
            ViewBag.Likes = Binder.GetLikesForComment(idComment);
            return PartialView();

        }
        [HttpPost]
        public ActionResult AddLike(Guid idPhoto)
        {
            Photo photo = Binder.GetAllPhoto().FirstOrDefault(i => i.IDPhoto == idPhoto);
            Binder.AddLike(idPhoto);
            idPhoto = photo.IDPhoto;
            return RedirectToAction("GetPhotoView", "File", new { idPhoto });
            //return RedirectToAction("Profile", "User", user);
        }
        [HttpPost]
        public ActionResult AddLikeForComment(Guid idComment)
        {
            Comment comment = Binder.GetComments().FirstOrDefault(i => i.CommentId == idComment);
            Binder.AddLike(idComment);
            idComment = comment.CommentId;
            return RedirectToAction("GetPhotoView", "File", new { idComment });
            //return RedirectToAction("Profile", "User", user);
        }
        [HttpPost]
        public ActionResult DeleteLike(Guid idPhoto)
        {
            Photo photo = Binder.GetAllPhoto().FirstOrDefault(i => i.IDPhoto == idPhoto);
            Binder.DeleteLike(idPhoto);
            idPhoto = photo.IDPhoto;
            return RedirectToAction("GetPhotoView", "File", new { idPhoto });
            //return RedirectToAction("Profile", "User", user);
        }
        [HttpPost]
        public ActionResult DeleteLikeForComment(Guid idComment)
        {
            Comment comment = Binder.GetComments().FirstOrDefault(i => i.CommentId == idComment);
            Binder.DeleteLike(idComment);
            idComment = comment.CommentId;
            return RedirectToAction("GetPhotoView", "File", new { idComment });
            //return RedirectToAction("Profile", "User", user);
        }
    }
}