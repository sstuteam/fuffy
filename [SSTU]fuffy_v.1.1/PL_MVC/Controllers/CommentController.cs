using PL_MVC.Models;
using System;
using System.Linq;
using System.Collections;
using System.Web.Mvc;
using System.Collections.Generic;

namespace PL_MVC.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult GetComment(Guid id) //это правильно
        {

            var comments = Binder.GetComments(id).OrderBy(x=>x.Date);
            ViewBag.UserId = AuthHelper.GetUser(HttpContext).idUser;
            ViewBag.userRoleId = AuthHelper.GetUser(HttpContext).RoleId;
            if (comments.Count() != 0 )
            {
                return PartialView(comments);
            }
            else return null;
            
        }
        //[PageAuthorize(RoleID = 0)PageAuthorize(RoleID = 2)]
        [HttpPost]       
        public ActionResult AddComment(string text, Guid idPhoto)
        {
            Photo photo = Binder.GetAllPhoto().FirstOrDefault(i => i.IDPhoto == idPhoto);
            
            var user = AuthHelper.GetUser(HttpContext);
            ViewBag.userRoleId = AuthHelper.GetUser(HttpContext).RoleId;
            if (text != null)
            {

                Comment comment = new Comment()
                {
                    PhotoId = idPhoto,
                    UserId = user.idUser,
                    Like = 0,
                    Text = text
                };
                if (user.RoleId !=3 && Request.IsAjaxRequest())
                {
                    Binder.AddComment(comment);
                    return Json(Binder.GetComments(idPhoto).OrderBy(x => x.Date), JsonRequestBehavior.AllowGet);
                }
            }
            idPhoto = photo.IDPhoto;
            return RedirectToAction("GetPhotoView", "File", new { idPhoto });
            //return RedirectToAction("Profile", "User", user);
        }
        //[PageAuthorize(RoleID = 0)]
        public ActionResult DeleteComment(Guid commentId)
        {
            Comment comment = Binder.GetComments().FirstOrDefault(x => x.CommentId == commentId);
            Guid idPhoto = comment.PhotoId;
            if (Request.IsAjaxRequest())
            {
                Binder.DeleteComment(commentId);
                return Json(Binder.GetComments(idPhoto).OrderBy(x => x.Date), JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("GetPhotoView", "File", new { idPhoto});            
        }
        [HttpGet]
        //[PageAuthorize(RoleID = 2)]
        public ActionResult EditComment(Guid commentId)
        {
            ViewBag.Prf = AuthHelper.GetUser(HttpContext).Preference;
            Comment comment = Binder.GetComments().FirstOrDefault(x => x.CommentId == commentId);
            return View(comment);
        }
        [HttpPost]
        //[PageAuthorize(RoleID = 2)]
        public ActionResult EditComment(Comment comment)
        {
            Binder.EditComment(comment);
            Guid idPhoto = comment.PhotoId;
            return RedirectToAction("GetPhotoView", "File", new { idPhoto });
        }
    }
}