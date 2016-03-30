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
            return dal.AddAlbum(album);
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
            return dal.GetAllAlbums().FirstOrDefault(x => x.IDUser == IDUser && x.Name == "Other").IDAlbum;
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
        public IEnumerable<Album> GetAllAlbums()
        {
            return dal.GetAllAlbums();
        }
        public string GetAllAlbumsForUser(Guid iduser)
        {
            return dal.GetAllAlbumsForUser(iduser);
        }

        public IEnumerable<Photo> GetAllPhoto(Guid id)
        {
            return dal.GetAllPhoto(id);
        }
        //public User GetUser(string Login, string Password)   //*
        //{
        //    return dal.GetUser(Login, Password);
        //}
    }
}
