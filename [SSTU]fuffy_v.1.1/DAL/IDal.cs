using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public interface IDAL
    {

        //фото
        bool AddAlbum(Album album);
        IEnumerable<Photo> GetAllPhoto();
        IEnumerable<Photo> GetAllPhotoForUser(Guid id);
        IEnumerable<Photo> GetAllPhotoForAlbum(Guid idAlbum);
        IEnumerable<Album> GetAllAlbums(Guid id);
        Album GetAlbum(Guid idAlbum);
        bool AddPhoto(Photo image);
        bool DeletePhoto(Guid idPhoto);
        bool AddAvatar(Guid UserId, Photo image);
        bool GetAvatar(Guid UserId);
        IEnumerable<Photo> Search(string name, string fragment);
        Photo GetPhoto(Guid idPhoto);
        //комментарии
        bool AddComment(Comment comment);
        IEnumerable<Comment> GetComments(Guid id);
        int GetLikesPhoto(Guid Id);
        bool AddLikePhoto(Guid Id, Like like);
        bool DeleteLikePhoto(Guid Id);
        int GetLikesComment(Guid Id);
        bool AddLikeComment(Guid Id);
        bool DeleteLikeComment(Guid CommentId);
        IEnumerable<Comment> GetComments();

        //пользователи
        bool Add(User user);
        IEnumerable<User> GetAllUser();
        //IEnumerable<User> GetAllUserForUser();
        IEnumerable<Album> GetAllAlbumsForUser(Guid iduser);
        User GetUser(string cookie);                    //
        User GetUser(string Login, string Password);    //
        User GetUser(Guid id);
    }
}
