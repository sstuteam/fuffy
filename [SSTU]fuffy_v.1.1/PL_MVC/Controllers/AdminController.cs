using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PL_MVC.Models;

namespace PL_MVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [PageAuthorize(RoleID = 1)]
        public ActionResult AdminPanel()
        {
            //var user = AuthHelper.GetUser(HttpContext);
            //return View("~/Views/Admin/AdminPanel.cshtml", user);
            return RedirectToAction(nameof(Pages));
        }

        [PageAuthorize(RoleID = 1)]
        public ActionResult Pages()
        {
            return View("~/Views/Admin/Pages.cshtml");
        }

        public ActionResult UserLists()
        {
            return View("~/Views/Admin/Users.cshtml");
        }
    }
}