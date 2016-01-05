using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PL_MVC.Models;

namespace PL_MVC.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        public ActionResult Registration()
        {
            return View("~/Views/Registration/Registration.cshtml");
        }
        [HttpPost]
        public ActionResult Registration(User user)
        {            
            Binder.CheckLogin(user.Login);
            user.Cookies = Guid.NewGuid().ToString();
            user.idUser = Guid.NewGuid();
            Binder.AddUser(user);
            return RedirectToAction("Index", "Home");
        }
    }
}