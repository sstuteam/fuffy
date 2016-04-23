using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PL_MVC.Models;

namespace PL_MVC.Models
{
    public class ProfileView
    {
        public Photo photo { get; set; }
        public string name { get; set; }
        public Guid IdAlbum { get; set; }        
    }
}