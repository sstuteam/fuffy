using PL_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        [HttpGet]
        public ActionResult Settings()
        {
            ViewBag.Prf = AuthHelper.GetUser(HttpContext).Preference;
            User user = AuthHelper.GetUser(HttpContext);
            if (Request.IsAjaxRequest())
            {
                return View(user);
            }
            else
            return View(user);
        }
        [HttpPost]
        public ActionResult Settings(User user)
        {
            User userBeforeUpdate = AuthHelper.GetUser(HttpContext);
            ViewBag.PasswordBeforeUpdate = userBeforeUpdate.Password;
            if (user.Avatar == null)
            {
                user.Avatar = userBeforeUpdate.Avatar;
            }
            if (user.Cookies == null)
            {
                user.Cookies = userBeforeUpdate.Cookies;
            }
            if (user.countOfAlbum == 0)
            {
                user.countOfAlbum = userBeforeUpdate.countOfAlbum;
            }
            if (user.countOfLikes == 0)
            {
                user.countOfLikes = userBeforeUpdate.countOfLikes;
            }
            if (user.Email == null)
            {
                user.Email = userBeforeUpdate.Email;
            }
            if (user.Avatar == null)
            {
                user.Avatar = userBeforeUpdate.Avatar;
            }
            if (user.Name == null)
            {
                user.Name = userBeforeUpdate.Name;
            }
            if (user.Password == null && user.PasswordRepeat == null && user.Password != user.PasswordRepeat)
            {
                user.Password = userBeforeUpdate.Password; //тут паролю присваиваются куки (?)
            }
            if (user.Status == null)
            {
                user.Status = userBeforeUpdate.Status;
            }
            user.RoleId = userBeforeUpdate.RoleId;
            user.idUser = userBeforeUpdate.idUser;
            Binder.UpdateUser(user);
            return RedirectToAction("Profile", "User", new { user.idUser });
        }
    }
}