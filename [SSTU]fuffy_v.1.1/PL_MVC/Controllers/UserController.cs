using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PL_MVC.Models;

namespace PL_MVC.Controllers
{
    public class UserController : Controller
    {        
        // GET: User
        public ActionResult Index()
        {            
            return View();
        }
        //public string IsMyPhoto(Guid IdPhoto)
        //{

        //    Guid ID = AuthHelper.GetUser(HttpContext).idUser;
        //    if (Binder.GetAllPhotoForUser(ID).FirstOrDefault().IDPhoto == IdPhoto)
        //        return "1";
        //    else return "0";
        //}

        //[PageAuthorize(RoleID = 0)]        
        new public ActionResult Profile()
        {
            ViewBag.UserId = AuthHelper.GetUser(HttpContext).idUser;
            ViewBag.Id = AuthHelper.GetUser(HttpContext).idUser;
            var user = AuthHelper.GetUser(HttpContext);
            return View("~/Views/User/Profile.cshtml",user);
        }
        public ActionResult ChangeStatus(string Name)
        {
            var user = AuthHelper.GetUser(HttpContext);
            Binder.ChangeStatus(user.idUser,Name);
            return RedirectToAction("Profile");
        }
        
    }
}