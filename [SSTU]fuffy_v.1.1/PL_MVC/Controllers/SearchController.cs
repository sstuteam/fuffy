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
        public PartialViewResult PartialSearch(string name, string fragment, string userName, string prf)
        {
            IEnumerable<Photo> listAllPhoto = Binder.GetAllPhoto().Where(photo => photo.Category != "Album");
            var users = Binder.GetUsers().Where(item => item.Name == userName);
            if (name == null) { name = ""; }
            if (fragment == null) { fragment = ""; }
            if (userName == null) { userName = ""; }
            List<Photo> founded = new List<Photo>();
            if (users.Count() != 0 && users != null)
            {
                if (name == "" && fragment == "")
                {
                    foreach (var photo in listAllPhoto)
                    {
                        foreach (var user in users)
                        {
                            if (user.idUser == Binder.GetAlbumName(photo.IDAlbum).IDUser || user.Preference == Binder.GetUser(Binder.GetAlbumName(photo.IDAlbum).IDUser).Preference)
                            {
                                founded.Add(photo);
                            }
                        }
                    }
                }
                else {
                    foreach (var photo in listAllPhoto)
                    {
                        foreach (var user in users)
                        {
                            if ((user.idUser == Binder.GetAlbumName(photo.IDAlbum).IDUser || user.Preference == Binder.GetUser(Binder.GetAlbumName(photo.IDAlbum).IDUser).Preference) && photo.Spetification.Contains(fragment) && photo.Name == name)
                            {
                                founded.Add(photo);
                            }
                        }
                    }
                }
                if (fragment != "" && name == "")
                {
                    foreach (var photo in listAllPhoto)
                    {
                        foreach (var user in users)
                        {
                            if ((user.idUser == Binder.GetAlbumName(photo.IDAlbum).IDUser || user.Preference == Binder.GetUser(Binder.GetAlbumName(photo.IDAlbum).IDUser).Preference) && photo.Spetification.Contains(fragment))
                            {
                                founded.Add(photo);
                            }
                        }
                    }
                }
                else
                {
                    foreach (var photo in listAllPhoto)
                    {
                        foreach (var user in users)
                        {
                            if ((user.idUser == Binder.GetAlbumName(photo.IDAlbum).IDUser || user.Preference == Binder.GetUser(Binder.GetAlbumName(photo.IDAlbum).IDUser).Preference) && photo.Name == name)
                            {
                                founded.Add(photo);
                            }
                        }
                    }
                }
                return PartialView(founded);
            }
            
            return PartialView(listAllPhoto.Where(photo=>Binder.GetUsers().FirstOrDefault().Preference==prf || photo.Spetification.Contains(fragment) || photo.Name==name));
        }
    }
}