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
            ViewBag.Prf = AuthHelper.GetUser(HttpContext).Preference;
            var allUsers = Binder.GetUsers();
            IEnumerable<User> sorted = allUsers.OrderBy(x => x.GetCountOfLikesForUser()).Reverse();
            //if (Request.IsAjaxRequest())
            //{
            //    return View(sorted);
            //}
            /*else*/
            return View(sorted);
        }
        public ActionResult GetOtherUserPage(Guid idOtherUser)
        {
            ViewBag.UserId = AuthHelper.GetUser(HttpContext).idUser;
            ViewBag.Id = idOtherUser;
            ViewBag.Prf= Binder.GetUser(idOtherUser).Preference;
            Models.User user = Binder.GetUser(idOtherUser);
            return View("~/Views/User/Profile.cshtml", user);
        }
    }
}