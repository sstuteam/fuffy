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
        public PartialViewResult PartialPhoto( string politic,string sport, string sience, string calture)
        {
            var users = Binder.GetUsers();
            var photoes = Binder.GetAllPhoto();
            List<NewsClass> newsclass = new List<NewsClass>();
            for (int i=0; i<photoes.Count();i++)
            {
                NewsClass usless = new NewsClass();
                usless.photo = photoes.ElementAt(i);
                // usless.user = null;
                for (int k = 0; k < users.Count(); k++)
                {                   
                    IEnumerable<Photo> hi = Binder.GetAllPhotoForUser(users.ElementAt(k).idUser);
                    for (int y = 0; y < hi.Count(); y++)
                    {
                        if (hi.ElementAt(i).IDPhoto == usless.photo.IDPhoto)
                            usless.user = users.ElementAt(k);
                    }
                    //if (hi.Contains(photoes.ElementAt(i)))
                    //{ usless.user = users.ElementAt(k); }
                }
               
                newsclass.Add(usless);         
            }
            //for (int i = 0; i < photoes.Count(); i++)
            //{
            //    for (int k = 0; k < users.Count(); k++)
            //    {
            //        IEnumerable<Photo> hi = Binder.GetAllPhotoForUser(users.ElementAt(k).idUser);
            //        if (hi.Contains(photoes.ElementAt(i)))
            //        { newsclass.ElementAt(i).user = users.ElementAt(k); }
            //    }
            //}
            List<NewsClass> T=new List<NewsClass>();
            if (politic != null||sport!=null||sience!=null||calture!=null)
            {
                for (int i = 0; i < photoes.Count(); i++)
                {
                    if (newsclass.ElementAt(i).photo.Category == politic|| newsclass.ElementAt(i).photo.Category == sport|| newsclass.ElementAt(i).photo.Category == sience|| newsclass.ElementAt(i).photo.Category == calture)
                        T.Add(newsclass.ElementAt(i));
                }
                IEnumerable<NewsClass> Rect = T;
                return PartialView("~/Views/News/NewsGet.cshtml", Rect);
            }
            else
            {
                IEnumerable<NewsClass> classforresult = newsclass.OrderBy(tt => tt.photo.Data);
                return PartialView("~/Views/News/NewsGet.cshtml", classforresult);                
            }
        }
    }
}