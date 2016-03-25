using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PL_MVC.Models;
using System.IO;

namespace PL_MVC.Controllers
{
    public class FileController : Controller
    {
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase uploaded)
        {
            var user = AuthHelper.GetUser(HttpContext);
            if (uploaded!=null)
            {                 
                Photo image = new Photo()
                {
                    IDPhoto=Guid.NewGuid(),
                    Name="photo"+(string)uploaded.ContentType,
                    Spetification=" ",
                    CountLikes=0,
                    IDAlbum=Binder.GetIdAlbum(user.idUser,"Other"),
                    Image=new byte[uploaded.ContentLength]
                };
                using (BinaryReader br = new BinaryReader(uploaded.InputStream))
                {
                    image.Image = br.ReadBytes(image.Image.Length);
                }
                Binder.Add(image);
                //return File(image.Image, uploaded.ContentType);                
            }
            return View("~/Views/User/Profile.cshtml", user);
        }
        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }
    }
}