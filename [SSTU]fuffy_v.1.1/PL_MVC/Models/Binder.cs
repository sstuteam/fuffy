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
        public static bool DeletePhoto(Guid idPhoto)
        {
            return bll.DeletePhoto(idPhoto);
        }
        public static bool DeleteUser(string name)
        {
            return bll.DeleteUser(name);
        }
        public static bool CreateAdmin(string name)
        {
            return bll.CreateAdmin(name);/////////
        }
        public static bool CreateModerator(string name)
        {
            return bll.CreateModerator(name);/////////////////////
        }
        public static bool BlockUser(string name)
        {
            return bll.BlockUser(name);////////////////////
        }
        public static bool UnBlockUser(string name)
        {
            return bll.UnBlockUser(name);//////////////////////////
        }
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
        public static IEnumerable<User> GetUsers()
        {
            List<User> listUser = new List<User>();
            foreach (var item in bll.GetAllUser())
            {
                listUser.Add(new User()
                {
                    idUser = item.idUser,
                    IsBlocked = item.IsBlocked,
                    RoleId = item.RoleId,
                    Cookies = item.Cookies,
                    countOfAlbum = item.countOfAlbum,
                    Password = item.Password,
                    PasswordRepeat = item.Password,
                    countOfLikes = item.countOfLikes,
                    Email = item.Email,
                    Login = item.Login,
                    Name = item.Name,
                    Status = item.Status
                }
                    );
            }
            return listUser;
        }
        public static Guid GetIdAlbum(Guid idUser, string v)
        {
            return bll.GetIdAlbum(idUser, v);
        }
        public static Photo GetAlbumPhoto(Guid idAlbum)
        {
           /* Entities.Photo entPhoto=*/ return bll.GetAlbumPhoto(idAlbum);
            //Photo photo = new Photo()
            //{
            //    IDAlbum = entPhoto.IDAlbum,
            //    IDPhoto = entPhoto.IDPhoto,
            //    Data = entPhoto.Data,
            //    CountLikes = entPhoto.CountLikes,
            //    Image = entPhoto.Image,
            //    Name = entPhoto.Name,
            //    Spetification = entPhoto.Spetification,
            //    ImageType = entPhoto.ImageType
            //};
            //return photo;
            
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
            return bll.AddComment(comment);
        }
        public static bool DeleteComment(Guid commentId)
        {
            return bll.DeleteComment(commentId);
        }
       
        public static IEnumerable<Photo> GetAllPhotoForAlbum(Guid idAlbum)
        {
            List<Photo> listPhotoForAlbum = new List<Photo>();
            foreach (var item in bll.GetAllPhotoForAlbum(idAlbum))
            {
                listPhotoForAlbum.Add(new Photo()
                {
                    IDAlbum = item.IDAlbum,
                    CountLikes = item.CountLikes,
                    IDPhoto = item.IDPhoto,
                    Image = item.Image,
                    ImageType = item.ImageType,
                    Name = item.Name,
                    Spetification = item.Spetification,
                    Data=item.Data

                });

            }
            return listPhotoForAlbum;
        }

        public static IEnumerable<Album> GetAllAlbums(Guid ID)
        {
            List<Album> listAlbum = new List<Album>();
            foreach (var item in bll.GetAllAlbums(ID))
            {
                listAlbum.Add(
                    new Album(){
                        Spetification = item.Spetification,
                        Name = item.Name,
                        IDAlbum = item.IDAlbum,
                        IDUser = item.IDUser
                    });
            }
            return listAlbum;
        }
        public static IEnumerable<Album> GetAllAlbumsForUser(Guid iduser)
        {
            List<Album> listAlbumForUser = new List<Album>();
            foreach (var item in bll.GetAllAlbumsForUser(iduser))
            {
                listAlbumForUser.Add(
                    new Album()
                    {
                        Spetification = item.Spetification,
                        Name = item.Name,
                        IDAlbum = item.IDAlbum,
                        IDUser = item.IDUser
                    });
            }
            return listAlbumForUser;
        }
        public static IEnumerable<Comment> GetComments(Guid id)
        {
            List<Comment> comments = new List<Comment>();
            foreach (var item in bll.GetComments(id))
            {
                comments.Add(new Comment()
                {
                    CommentId = item.CommentId,
                    Date = item.Date,
                    Like = item.Likes,
                    PhotoId = item.PhotoId,
                    Text = item.Text,
                    UserId = item.UserId
                });
            }
            return comments;
        }
        public static IEnumerable<Comment> GetComments()
        {
            List<Comment> comments = new List<Comment>();
            foreach (var item in bll.GetComments())
            {
                comments.Add(new Comment()
                {
                    CommentId = item.CommentId,
                    Date = item.Date,
                    Like = item.Likes,
                    PhotoId = item.PhotoId,
                    Text = item.Text,
                    UserId = item.UserId
                });
            }
            return comments;
        }
        public static IEnumerable<Photo> Search(string name, string fragment)
        {
            List<Photo> found = new List<Photo>();
            foreach (var item in bll.Search(name, fragment))
            {
                found.Add(new Photo()
                {
                    IDAlbum = item.IDAlbum,
                    CountLikes = item.CountLikes,
                    IDPhoto = item.IDPhoto,
                    Image = item.Image,
                    ImageType = item.ImageType,
                    Name = item.Name,
                    Spetification = item.Spetification,
                    Data=item.Data
                });
            }
            return found;
        }
        public static IEnumerable<Photo> GetAllPhoto()
        {
            List<Photo> photoes = new List<Photo>();
            foreach (var item in bll.GetAllPhoto())
            {
                photoes.Add(new Photo()
                {
                    IDAlbum = item.IDAlbum,
                    IDPhoto = item.IDPhoto,
                    CountLikes = item.CountLikes,
                    Image = item.Image,
                    ImageType = item.ImageType,
                    Name = item.Name,
                    Spetification = item.Spetification,
                    Data = item.Data,
                    Category = item.Category              //поправил
                });
            }
            return photoes;
        }
        public static IEnumerable<Photo> GetAllPhotoForUser(Guid id)
        {
            List<Photo> photoesForUser = new List<Photo>();
            foreach (var item in bll.GetAllPhotoForUser(id))
            {
                photoesForUser.Add(new Photo()
                {
                    IDPhoto = item.IDPhoto,
                    IDAlbum = item.IDAlbum,
                    CountLikes = item.CountLikes,
                    ImageType = item.ImageType,
                    Image = item.Image,
                    Name = item.Name,
                    Spetification = item.Spetification,
                    Data = item.Data
                });
            }
            return photoesForUser;
        }

        public static Album GetAlbumName(Guid iDAlbum)
        {
            //Album album = new Album();
            //album.Spetification = bll.GetAlbum(iDAlbum).Spetification;
            //album.Name = bll.GetAlbum(iDAlbum).Name;
            //album.IDAlbum = bll.GetAlbum(iDAlbum).IDAlbum;
            //album.IDUser = bll.GetAlbum(iDAlbum).IDUser;
            //return album;
            return bll.GetAlbum(iDAlbum); //норм так то
        }
        public static Photo GetPhoto(Guid idPhoto)
        {
            return bll.GetPhoto(idPhoto);
        }
        public static User GetUser(Guid id)
        {
            return bll.GetUser(id);
        }
        public static int GetLikes(Guid Id)
        {
            return bll.GetLikesPhoto(Id);
        }
        public static bool AddLike(Guid Id, Like like)
        {
            Like likeVM = new Like()
            {
                PhotoId = like.PhotoId,
                UserId = like.UserId
            };
            return bll.AddLikePhoto(Id, likeVM);
        }
        public static bool DeleteLike(Guid Id)
        {
            return bll.DeleteLikePhoto(Id);
        }
        public static bool UpdateUser(User user)
        {
            return bll.UpdateUser(user);
        }
        public static bool EditComment(Comment comment)
        {
            return bll.EditComment(comment);
        }
        public static bool EditPhoto(Photo photo)
        {
            return bll.EditPhoto(photo);
        }
    }
}
