using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL
{
    public interface IBLL
    {
        //фотографии
        bool DeletePhoto(Guid idPhoto);
        bool CreateAdmin(string name);       
        bool CreateModerator(string name);
        bool BlockUser(string name);
        bool UnBlockUser(string name);
        bool DeleteUser(string name);
        bool AddAlbum(Album album);
        bool AddPhoto(Photo image);
        bool EditAvatar(Guid UserId, Photo image);
        bool GetAvatar(Guid UserId);
        IEnumerable<Photo> GetAllPhotoForUser(Guid id);
        IEnumerable<Photo> GetAllPhoto();
        Guid GetIdAlbum(Guid IDUser, string nameAlbom);
        Album GetAlbum(Guid idAlbum);
        Photo GetAlbumPhoto(Guid idAlbum);
        IEnumerable<Photo> Search(string name, string fragment);
        IEnumerable<Photo> GetAllPhotoForAlbum(Guid idAlbum);
        Photo GetPhoto(Guid idPhoto);
        bool EditPhoto(Photo photo);



        //комментарии
        IEnumerable<Comment> GetComments(Guid id);
        bool AddComment(Comment comment);
        bool DeleteComment(Guid commentId);
        bool CheckAlbumName(Guid Id, string Name);
        int GetLikesPhoto(Guid Id);
        bool AddLikePhoto(Guid Id, Like like);
        bool DeleteLikePhoto(Guid Id);
        int GetLikesComment(Guid CommentId);
        bool AddLikeComment(Guid CommentId);
        bool DeleteLikeComment(Guid CommentId);
        IEnumerable<Comment> GetComments();
        bool EditComment(Comment comment);

        //пользователи
        bool AddUser(User user);
        bool CheckLogin(string Login);
        IEnumerable<Album> GetAllAlbums(Guid id);
        IEnumerable<Album> GetAllAlbumsForUser(Guid iduser);
        User GetUser(string cookie);
        User GetUser(string Login, string Password);
        User GetUser(Guid id);
        IEnumerable<User> GetAllUser();
        bool UpdateUser(User user);
    }
}
