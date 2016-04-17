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
        [HttpPost]
        public ActionResult Search(string name, string fragment)
        {
            var listPhoto = Search(name, fragment);
            return View(listPhoto);
        }
        [HttpGet]
        public ActionResult Search()
        {
            return View("~/Views/Search/PartialSearch.cshtml"); ;
        }
    }
}