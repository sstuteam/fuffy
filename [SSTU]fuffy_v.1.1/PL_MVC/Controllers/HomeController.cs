using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PL_MVC.Models;

namespace PL_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {        
            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult RepeatIndex()
        {
            return View("~/Views/Home/Index.cshtml",new Home(true));
        }
        public PartialViewResult GetPopularPhotos()
        {
            return PartialView(Binder.GetAllPhoto().OrderBy(x => x.CountLikes).Reverse().Take(4).ToArray());
        }
        public PartialViewResult GetPopularUsers()
        {
            return PartialView(Binder.GetUsers().OrderBy(x => x.countOfLikes).Take(4).ToArray());
        }

    }
}