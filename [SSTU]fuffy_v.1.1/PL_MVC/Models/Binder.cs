using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using PL_MVC.Models;

namespace PL_MVC.Models
{
    public static class Binder
    {
        public static IBLL bll = new Logic();
        public static bool AddUser(User user)
        {
            return bll.AddUser((Entities.User)user);
        }

        public static bool CheckLogin(string Login)
        {
            return bll.CheckLogin(Login);
        }
        public static User GetUser(string cookie)
        {
            return bll.GetUser(cookie);
        }

        public static User GetUser(string Login, string Password)
        {
            return bll.GetUser(Login, Password);
        }

        public static Guid GetIdAlbum(Guid idUser, string v)
        {
            return bll.GetIdAlbum(idUser, v);
        }

        public static bool AddAlbum(Album album)
        {
            return bll.AddAlbum(album);
        }

        public static bool Add(Photo image)
        {
            return bll.AddPhoto(image);
        }
        public static bool AddComment(Comment comment)
        {
            return bll.AddComment((Entities.Comment)comment);
        }
        public static IEnumerable<Entities.Album> GetAllAlbums(Guid ID)
        {
            return bll.GetAllAlbums(ID);
        }
        public static IEnumerable<Entities.Album> GetAllAlbumsForUser(Guid iduser)
        {
            return bll.GetAllAlbumsForUser(iduser);
        }
        public static IEnumerable<Entities.Comment> GetComments()
        {
            return bll.GetComments();
        }
        public static IEnumerable<Entities.Photo> Search(string name, string fragment)
        {
            return bll.Search(name, fragment);
        }
        public static IEnumerable<Entities.Photo> GetAllPhoto()
        {
            return bll.GetAllPhoto();
        }
        public static IEnumerable<Entities.Photo> GetAllPhotoForUser(Guid id)
        {
            return bll.GetAllPhotoForUser(id);
        }

        public static Entities.Album GetAlboumName(Guid iDAlbum)
        {
            return bll.GetAlboum(iDAlbum);
        }
    }
}
