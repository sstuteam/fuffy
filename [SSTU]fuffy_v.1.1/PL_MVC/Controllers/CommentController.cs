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
        public ActionResult Comment() //это правильно
        {
            IEnumerable<Entities.Comment> comm = Binder.GetComments();
            return Json(comm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddComment(string text)
        {
            var com = Binder.AddComment(new Models.Comment(text));
            return Json(com, JsonRequestBehavior.AllowGet);
        }
    }
}