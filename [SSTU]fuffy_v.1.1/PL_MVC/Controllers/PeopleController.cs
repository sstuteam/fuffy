using PL_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult People()
        {
            var allUsers = Binder.GetUsers();
            return View(allUsers);
        }
        public ActionResult GetOtherUserPage(Guid idOtherUser)
        {
            Models.User user = Binder.GetUser(idOtherUser);
            return View("~/Views/User/Profile.cshtml", user);
        }
    }
}