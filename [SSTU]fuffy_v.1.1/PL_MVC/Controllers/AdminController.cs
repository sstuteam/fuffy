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
            return RedirectToAction(nameof(Users));
        }

        [PageAuthorize(RoleID = 1)]
        public ActionResult Users()
        {
            var allUsers = Binder.GetUsers();
            IEnumerable<User> sorted = allUsers.OrderBy(x => x.GetCountOfLikesForUser()).Reverse();
            return View("~/Views/Admin/Users.cshtml", sorted);
        }
        [PageAuthorize(RoleID = 1)]
        public ActionResult UserLists()
        {
        var allUsers = Binder.GetUsers();
        IEnumerable<User> sorted = allUsers.OrderBy(x => x.GetCountOfLikesForUser()).Reverse();        
            return View("~/Views/Admin/Users.cshtml",sorted);
        }
        [PageAuthorize(RoleID = 1)]
        public ActionResult Operation(string Name,string action)//////////////////////////////////////////////////////////////////////////////////////////
        {
            if (Name != null)
            {
                bool t=false;
                if (action == "Delete")
                { t = Binder.DeleteUser(Name); }
                else if (action == "Block")
                { t = Binder.BlockUser(Name); }
                else if (action == "UnBlock")
                { t = Binder.UnBlockUser(Name); }
                else if (action == "Moderator")
                { t = Binder.CreateModerator(Name); }
                else if (action == "Admin")
                { t = Binder.CreateAdmin(Name); }
                else return null;
                if (t == true)
                {
                    return RedirectToAction(nameof(Users));
                }
                else return null;
            }
            else return null;
        }      
    }
}