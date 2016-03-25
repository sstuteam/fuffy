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
        [HttpPost]
        public IEnumerable<Photo> Search(string name, string fragment)
        {
            IEnumerable<Photo> listPhoto = Search(name, fragment);
            return listPhoto;
        }
	}
}