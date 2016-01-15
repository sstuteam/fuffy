using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PL_MVC.Models;

namespace PL_MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(Home homeModel)
        {
            User user = Binder.GetUser(homeModel.Login, homeModel.Password);
            if (user!=null)
            {
                AuthHelper.LogInUser(HttpContext, user.Cookies);
                switch (user.RoleId)
                {
                    case 0: return RedirectToAction(nameof(UserController.Profile), "User");
                    case 1: return RedirectToAction(nameof(AdminController.AdminPanel), "Admin"); 
                }
            }            
            return RedirectToAction("RepeatIndex", "Home");
        }

        public ActionResult LogOff()
        {
            AuthHelper.LogOffUser(HttpContext);

            return RedirectToAction("Index", "Home");
        }
    }
}