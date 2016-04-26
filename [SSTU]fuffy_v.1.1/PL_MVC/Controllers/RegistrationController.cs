using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PL_MVC.Models;
using System.IO;

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
        public ActionResult Registration(User user, HttpPostedFileBase uploaded/*,string Hobbies*/)
        {
            Binder.CheckLogin(user.Login);
            user.Cookies = Guid.NewGuid().ToString();
            user.idUser = Guid.NewGuid();
            Photo avatar = new Photo()
            {
                IDPhoto = Guid.NewGuid(),                  
                Image = new byte[uploaded.ContentLength]
            };
            using (BinaryReader br = new BinaryReader(uploaded.InputStream))
            {
                avatar.Image = br.ReadBytes(avatar.Image.Length);
            }
            Album album = new Album()
            {
                IDAlbum = Guid.NewGuid(),
                IDUser = user.idUser,
                Name = "Other",
                Spetification = "No spetification"
            };
            user.Avatar = avatar.Image;
            //user.Hobbies = Hobbies;//передаем строку с предпочтением
            Binder.AddUser(user);
            //Binder.AddAvatar(user.idUser, avatar);
            Binder.AddAlbum(album);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult AddUser(User user)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}