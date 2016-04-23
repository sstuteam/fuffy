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
        [HttpGet]
        public ActionResult SearchResult()
        {
            return View("PartialSearch");
        }
        [HttpGet]
        public ActionResult PartialSearch(string name, string fragment)
        {
            if (name != null || fragment != null)
            {
                IEnumerable<Photo> listPhoto = Binder.Search(name, fragment);
                if (listPhoto.Count() != 0)
                {
                    return PartialView(listPhoto);
                }
            }
            return View("Search");
        }
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string name, string fragment)
        {
            if (name != null || fragment != null)
            {
            IEnumerable<Photo> listPhoto = Binder.Search(name, fragment);
            if (listPhoto.Count() != 0)
            {
                return PartialView("PartialSearch", listPhoto);
            }
            }
            return View();
        }
    }
}