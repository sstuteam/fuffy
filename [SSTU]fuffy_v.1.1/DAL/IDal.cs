﻿using System;
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
        IEnumerable<Album> GetAllAlbums(Guid id);
        Album GetAlbum(Guid idAlbum);
        bool AddPhoto(Photo image);
        IEnumerable<Photo> Search(string name, string fragment);
        //комментарии
        bool AddComment(Comment comment);
        IEnumerable<Comment> GetComments();
        int GetLikes(Guid Id);
        bool AddLike(Guid Id);
        bool DeleteLike(Guid Id);

        //пользователи
        bool Add(User user);
        IEnumerable<User> GetAllUser();
        IEnumerable<Album> GetAllAlbumsForUser(Guid iduser);
        User GetUser(string cookie);                    //
        User GetUser(string Login, string Password);    //

    }
}
