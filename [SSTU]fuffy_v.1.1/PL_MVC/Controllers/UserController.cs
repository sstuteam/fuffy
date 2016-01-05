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
        
       
        [PageAuthorize(RoleID = 0)]        
        public ActionResult Profile()
        {
            var user = AuthHelper.GetUser(HttpContext);
            return View("~/Views/User/Profile.cshtml",user);
        }      

    }
}