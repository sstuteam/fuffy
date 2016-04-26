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
            return View("~/Views/News/News.cshtml");
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
        public PartialViewResult PartialPhoto( string politic,string sport, string sience, string calture)
        {
            var photoes = Binder.GetAllPhoto();
            List<Photo> T=new List<Photo>();
            if (politic != null||sport!=null||sience!=null||calture!=null)
            {
                for (int i = 0; i < photoes.Count(); i++)
                {
                    if (photoes.ElementAt(i).Category == politic|| photoes.ElementAt(i).Category ==sport|| photoes.ElementAt(i).Category ==sience|| photoes.ElementAt(i).Category ==calture)
                        T.Add(photoes.ElementAt(i));
                }
                IEnumerable<Photo> Rect = T;
                return PartialView("~/Views/News/NewsGet.cshtml", Rect);
            }
            else
            {
                IEnumerable<Photo> sortedPhotoes = photoes.OrderBy(photo => photo.Name);
                return PartialView("~/Views/News/NewsGet.cshtml", sortedPhotoes);
            }
        }
    }
}