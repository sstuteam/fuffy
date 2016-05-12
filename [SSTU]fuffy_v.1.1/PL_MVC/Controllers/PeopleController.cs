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
        [Authorize]
        public ActionResult People()
        {
            var allUsers = Binder.GetUsers();
            IEnumerable<User> sorted = allUsers.OrderBy(x => x.GetCountOfLikesForUser()).Reverse();
            return View(sorted);
        }
        public ActionResult GetOtherUserPage(Guid idOtherUser)
        {
            ViewBag.UserId = AuthHelper.GetUser(HttpContext).idUser;
            ViewBag.Id = idOtherUser;
            Models.User user = Binder.GetUser(idOtherUser);
            return View("~/Views/User/Profile.cshtml", user);
        }
    }
}