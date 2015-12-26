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
        [HttpGet]      
        public ActionResult Registration()
        {
            return View("~/Views/User/RegisterPage/Registration.cshtml");
            //return View();
        }
        [HttpPost]
        public ActionResult Registration(User user)
        {
            Binder.CheckLogin(user.login);

            //Binder.AddUser(user);
            return RedirectToAction("Index","Home");
        }
        public ActionResult Profile(int id)
        {
            return View();
        }

    }
}