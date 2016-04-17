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
        IEnumerable<Photo> Search(string name, string fragment);
        Photo GetPhoto(Guid idPhoto);
        //комментарии
        bool AddComment(Comment comment);
        IEnumerable<Comment> GetComments(Guid id);
        int GetLikesPhoto(Guid Id);
        bool AddLikePhoto(Guid Id);
        bool DeleteLikePhoto(Guid Id);
        int GetLikesComment(Guid CommentId,Guid PhotoId);
        bool AddLikeComment(Guid CommentId, Guid PhotoId);
        bool DeleteLikeComment(Guid CommentId, Guid PhotoId);

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
