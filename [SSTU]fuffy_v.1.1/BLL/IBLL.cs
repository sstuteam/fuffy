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
        Guid GetIdAlbum(Guid IDUser, string nameAlbom);
        IEnumerable<Photo> Search(string name, string fragment);

        //комментарии
        IEnumerable<Comment> GetComments();
        bool AddComment(Comment comment);

        //пользователи
        bool AddUser(User user);
        bool CheckLogin(string Login);
        User GetUser(string cookie);
        User GetUser(string Login, string Password);
        
    }
}
