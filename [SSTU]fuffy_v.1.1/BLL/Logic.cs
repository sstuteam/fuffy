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
            image.Data = DateTime.Now;
            return dal.AddPhoto(image);
        }
        public bool DeletePhoto(Guid idPhoto)
        {
           return dal.DeletePhoto(idPhoto);
           
        }
        public bool AddAvatar(Guid UserId, Photo image)
        {
            return dal.AddAvatar(UserId, image);
        }
        public bool GetAvatar(Guid UserId)
        {
            return dal.GetAvatar(UserId);
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
            comment.CommentId = Guid.NewGuid();
            comment.Date = DateTime.Now;
            return dal.AddComment(comment);
        }
        public bool DeleteComment(Guid commentId)
        {
            return dal.DeleteComment(commentId);
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

        public IEnumerable<Comment> GetComments(Guid id)
        {

            return dal.GetComments(id);
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
        public User GetUser(Guid id)
        {
            return dal.GetUser(id);
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
            return listPhoto.ToArray();
        }
        public IEnumerable<Album> GetAllAlbums(Guid ID)
        {
            return dal.GetAllAlbums(ID).ToArray();
        }
        public IEnumerable<Album> GetAllAlbumsForUser(Guid iduser)
        {
            return dal.GetAllAlbumsForUser(iduser).ToArray();
        }

        
        public IEnumerable<Photo> GetAllPhoto()
        {
            return dal.GetAllPhoto();
        }

        public IEnumerable<Photo> GetAllPhotoForUser(Guid id)
        {
            return dal.GetAllPhotoForUser(id).ToArray();
        }

        public Album GetAlbum(Guid idAlbum)
        {
            return dal.GetAlbum(idAlbum);
        }
        public Photo GetAlbumPhoto(Guid idAlbum)
        {
          var c =  dal.GetAllPhotoForAlbum(idAlbum);
            Photo photo1;
            if (c.Count()!= 0)
            {  photo1 = c.ElementAt(0); }
            else  photo1 = null;
            for (int i = 1; i < c.Count(); i++)
            {

                if (photo1.Data < c.ElementAt(i).Data)
                    photo1 = c.ElementAt(i);
            }
           
            return photo1;/////////////////////////////////////////////////////////////
        }
        public int GetLikesPhoto(Guid Id)
        {
            return dal.GetLikesPhoto(Id);
        }
        public bool AddLikePhoto(Guid Id, Like like)
        {
            return dal.AddLikePhoto(Id, like);
        }
        public bool DeleteLikePhoto(Guid Id)
        {
            return dal.DeleteLikePhoto(Id);
        }
        public int GetLikesComment(Guid CommentId)
        {
            return dal.GetLikesComment(CommentId);
        }
        public bool AddLikeComment(Guid CommentId)
        {
            return dal.AddLikeComment(CommentId);
        }
        public bool DeleteLikeComment(Guid CommentId)
        {
            return dal.DeleteLikeComment(CommentId);
        }

        public IEnumerable<Photo> GetAllPhotoForAlbum(Guid idAlbum)
        {
            return dal.GetAllPhotoForAlbum(idAlbum).ToArray();
        }

        public Photo GetPhoto(Guid idPhoto)
        {
            return dal.GetPhoto(idPhoto);
        }
        public IEnumerable<User> GetAllUser()
        {
            return dal.GetAllUser();
        }
        public IEnumerable<Comment> GetComments()
        {
            return dal.GetComments();
        }
        //public User GetUser(string Login, string Password)   //*
        //{
        //    return dal.GetUser(Login, Password);
        //}
        public bool UpdateUser(User user)
        {
            return dal.UpdateUser(user);
        }
    }
}
