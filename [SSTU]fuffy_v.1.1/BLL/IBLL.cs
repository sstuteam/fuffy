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
        bool AddAlbum(Album album);
        bool AddPhoto(Photo image);
        IEnumerable<Photo> GetAllPhotoForUser(Guid id);
        IEnumerable<Photo> GetAllPhoto();
        Guid GetIdAlbum(Guid IDUser, string nameAlbom);
        Album GetAlbum(Guid idAlbum);
        IEnumerable<Photo> Search(string name, string fragment);

        //комментарии
        IEnumerable<Comment> GetComments();
        bool AddComment(Comment comment);
        bool CheckAlbumName(Guid Id, string Name);
        //пользователи
        bool AddUser(User user);
        bool CheckLogin(string Login);
        IEnumerable<Album> GetAllAlbums(Guid id);
        IEnumerable<Album> GetAllAlbumsForUser(Guid iduser);
        User GetUser(string cookie);
        User GetUser(string Login, string Password);

    }
}
