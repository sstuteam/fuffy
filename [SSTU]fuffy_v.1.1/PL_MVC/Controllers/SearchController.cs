using PL_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class SearchController : Controller
    {
        //[HttpGet]
        //public ActionResult SearchResult()
        //{
        //    return View("PartialSearch");
        //}
        //[HttpGet]
        //public PartialViewResult PartialSearch(string name, string fragment)
        //{
        //    if (name != null || fragment != null)
        //    {
        //        IEnumerable<Photo> listPhoto = Binder.Search(name, fragment);
        //        if (listPhoto.Count() != 0)
        //        {
        //            return PartialView(listPhoto);
        //        }
        //    }
        //    return PartialView("Search");
        //}
        // GET: Search
        public ActionResult Search()
        {
            ViewBag.Prf = AuthHelper.GetUser(HttpContext).Preference;
            return View();
        }
        //[HttpPost]
        public PartialViewResult PartialSearch(string name, string fragment)
        {
            IEnumerable<Photo> listAllPhoto = Binder.GetAllPhoto();
            if (name != null || fragment != null)
            {
                IEnumerable<Photo> listPhoto = Binder.Search(name, fragment);
                if (listPhoto.Count() != 0)
                {
                    return PartialView(listPhoto);
                }
            }
            return PartialView(listAllPhoto.Where(x=>x.Spetification=="None"));
        }
    }
}