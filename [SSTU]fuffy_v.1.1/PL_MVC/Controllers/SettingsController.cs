using PL_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        [HttpGet]
        public ActionResult Settings()
        {
            User user = AuthHelper.GetUser(HttpContext);
            return View(user);
        }
        [HttpPost]
        public ActionResult Settings(User user)
        {
            Binder.UpdateUser(user);
            Guid idUser = user.idUser;
            return RedirectToAction("Profile", "User", new { idUser });
        }
    }
}