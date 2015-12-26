using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("~/Views/Home/fuffy/index.cshtml");
        }
        public bool LogIn()
        {
            return false;
        }
    }
}