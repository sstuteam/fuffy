using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class Logic : IBLL
    {
        IDAL dal;
        public Logic()
        {
            dal = new DBWork();
        }

        public bool AddPhoto(Photo image)
        {
            return dal.AddPhoto(image);
        }

        public bool AddAlbum(Album album)
        {
            //проверка для имени
            if (CheckAlbumName(album.IDUser, album.Name))
            { return dal.AddAlbum(album); }
            else { return false; }
        }

        public bool CheckAlbumName(Guid ID, string Name)
        {
            return dal.GetAllAlbums(ID).FirstOrDefault(x => x.Name == Name) == null;
        }
        public bool AddComment(Comment comment)
        {
            return dal.AddComment(comment);
        }

        public bool AddUser(User user)
        {
            if (CheckLogin(user.Login))
            {
                dal.Add(user);
                return true;
            }
            return false;
        }

        public bool CheckLogin(string Login)     //true - проверка пройдена, дубликат не найден,
        {                                        //false - такой логин уже существует
            return dal.GetAllUser().FirstOrDefault(x => x.Login == Login) == null;
        }

        public IEnumerable<Comment> GetComments()
        {
            IEnumerable<Comment> listcomments = dal.GetComments();
            return listcomments;
        }

        public Guid GetIdAlbum(Guid IDUser, string nameAlbom)
        {
            return dal.GetAllAlbums(IDUser).FirstOrDefault(x => x.IDUser == IDUser && x.Name == nameAlbom).IDAlbum;
        }

        public User GetUser(string cookie)   //*
        {
            var listUser = dal.GetAllUser();
            return listUser.FirstOrDefault(x => x.Cookies == cookie);
        }

        //public User GetUser(string cookie)   //**Посмотреть какая реальзация быстрее
        //{
        //    return dal.GetUser(cookie);
        //}

        public User GetUser(string Login, string Password)   //*Посмотреть какая реализация быстрее
        {
            var listUser = dal.GetAllUser();
            return listUser.FirstOrDefault(x => x.Login == Login && x.Password == DBWork.GetHashString(Password));
        }

        public IEnumerable<Photo> Search(string name, string fragment)
        {
            IEnumerable<Photo> listPhoto = dal.Search(name, fragment);
            return listPhoto;
        }
        public IEnumerable<Album> GetAllAlbums(Guid ID)
        {
            return dal.GetAllAlbums(ID);
        }
        public IEnumerable<Album> GetAllAlbumsForUser(Guid iduser)
        {
            return dal.GetAllAlbumsForUser(iduser);
        }

        
        public IEnumerable<Photo> GetAllPhoto()
        {
            return dal.GetAllPhoto();
        }

        public IEnumerable<Photo> GetAllPhotoForUser(Guid id)
        {
            return dal.GetAllPhotoForUser(id);
        }

        public Album GetAlbum(Guid idAlbum)
        {
            return dal.GetAlbum(idAlbum);
        }

        //public User GetUser(string Login, string Password)   //*
        //{
        //    return dal.GetUser(Login, Password);
        //}
    }
}
