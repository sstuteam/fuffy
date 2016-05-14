using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PL_MVC.Models;
using System.IO;

namespace PL_MVC.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult News()
        {
            ViewBag.Prf = AuthHelper.GetUser(HttpContext).Preference;
            //if (Request.IsAjaxRequest())
            //{
            //    return View();
            //}
            /*else*/
            return View();
        }
        
        public PartialViewResult NewsGet( string c1, string c2, string c3, string c4, string c5, string c6, string c7, string c8, string c9, string c10, string cat)
        {
            var photoes = Binder.GetAllPhoto();
            List<Photo> T=new List<Photo>();
            if (c1!= null||c2!=null||c3!=null||c4!=null||c5!=null||c6!=null||c7!=null||c8!=null||c9!=null||c10!=null||cat!=null)
            {
                for (int i = 0; i < photoes.Count(); i++)
                {
                    if (photoes.ElementAt(i).Category == c1 || photoes.ElementAt(i).Category == c2 || photoes.ElementAt(i).Category == c3 || photoes.ElementAt(i).Category == c4 || photoes.ElementAt(i).Category == c5 || photoes.ElementAt(i).Category == c6 || photoes.ElementAt(i).Category == c7 || photoes.ElementAt(i).Category == c8 || photoes.ElementAt(i).Category == c9 || photoes.ElementAt(i).Category == c10 || photoes.ElementAt(i).Category==cat)
                    {
                        T.Add(photoes.ElementAt(i));
                    }
                }
                IEnumerable<Photo> Rect = T;
                return PartialView(Rect);
            }
            else
            {
                IEnumerable<Photo> sortedPhotoes = photoes.OrderBy(photo => photo.Name);
                return PartialView(sortedPhotoes);
            }
        }
        //public ActionResult NewsModels(IEnumerable<Photo> ListPhoto)
        //{
        //    return View("~/Views/News/News.cshtml",ListPhoto);
        //}
        //[HttpGet]
        //public ActionResult NewsGet(string Category)
        //{
        //    var photoes = Binder.GetAllPhoto();
        //    IEnumerable<Photo> sortedPhotoes = photoes.OrderBy(photo => photo.Name);
        //    return RedirectToAction("NewsModel",sortedPhotoes);
        //}
    }
}