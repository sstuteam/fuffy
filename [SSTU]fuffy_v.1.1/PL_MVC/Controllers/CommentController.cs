using PL_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var comments = Binder.GetComments(id);
            if (comments.Count() != 0)
            {
                ViewBag.UserName = Binder.GetUser(comments.FirstOrDefault().UserId).Name;
                return PartialView(comments);
            }
            else return null;
            
        }
        [HttpPost]
        public ActionResult AddComment(string text, Guid idPhoto)
        {
            Photo photo = Binder.GetAllPhoto().FirstOrDefault(i => i.IDPhoto == idPhoto);
            var user = AuthHelper.GetUser(HttpContext);
            if (text != null)
            {

                Comment comment = new Comment()
                {
                    PhotoId = idPhoto,
                    UserId = user.idUser,
                    Like = 0,
                    Text = text
                };
                Binder.AddComment(comment);
            }
            idPhoto = photo.IDPhoto;
            return RedirectToAction("GetPhotoView", "File", new { idPhoto });
            //return RedirectToAction("Profile", "User", user);
        }
    }
}