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
            var idOtherUser = AuthHelper.GetUser(HttpContext).idUser;
            ViewBag.Prf = AuthHelper.GetUser(HttpContext).Preference;
            if (Request.IsAjaxRequest())
            {
                return View("~/Views/User/Profile.cshtml", user);
            }
            else return View("~/Views/User/Profile.cshtml", user);
        }
        [Authorize]
        public ActionResult ChangeStatus(Guid idUser, string status)
        {
            var user = Binder.GetUser(idUser); 
            Binder.ChangeStatus(user.idUser, status);
            if (Request.IsAjaxRequest())
            {
                return Json(user.Status, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("Profile");
        }
        
    }
}