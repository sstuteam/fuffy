using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_MVC.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; } // пароль будет зашифрованном виде

        public string PasswordRepeat { get; set; }
        public Guid idUser; //а нужен ли id в моделях?
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }   //
        public string Cookies { get; set; }
        public string Status { get; set; }
        /// <summary>
        /// Свойство, показывающее заблокирован ли пользователь
        /// </summary>
        public bool IsBlocked { get; set; }
        // public string  GetAllAlbums { get { if (Binder.GetAllAlbumsForUser(idUser) != "") return Binder.GetAllAlbumsForUser(idUser); else return "You've got no albums"; } set { }}
        ///// <summary>
        ///// Свойство показывающее имеет ли пользователь права администратора
        ///// </summary>
        //public bool IsAdmin { get; private set; }

        //public DateTime dateOfBirthday;  //Дата рождения
        public int countOfLikes; //Количество лайков, поставленных пользователю за все его фотографии
        public int countOfAlbum; //Количество альбомов   
        public IEnumerable<Album> GetAllAlbumsForUser()
        {
            return Binder.GetAllAlbumsForUser(idUser);
        }
        public IEnumerable<Photo> GetAllPhotoForUser()
        {
            return Binder.GetAllPhotoForUser(idUser);
        }
        public User()
        {
            idUser = Guid.NewGuid();
            RoleId = 0;
        }
        public static implicit operator Entities.User(User userModel)
        {
            if (userModel != null)
            {
                Entities.User userEntity = new Entities.User()
                {
                    idUser = userModel.idUser,
                    Cookies = userModel.Cookies,
                    countOfAlbum = userModel.countOfAlbum,
                    countOfLikes = userModel.countOfLikes,
                    Email = userModel.Email,
                    IsBlocked = userModel.IsBlocked,
                    Login = userModel.Login,
                    Name = userModel.Name,
                    Password = userModel.Password,
                    RoleId = userModel.RoleId,
                    Status = userModel.Status,
                    //GetAllAlbums = userModel.GetAllAlbums
                };
                return userEntity;
            }
            return null;
        }

        public static implicit operator User(Entities.User userEntity)
        {
            if (userEntity != null)
            {
                User userModel = new User()
                {
                    idUser = userEntity.idUser,
                    Cookies = userEntity.Cookies,
                    countOfAlbum = userEntity.countOfAlbum,
                    countOfLikes = userEntity.countOfLikes,
                    Email = userEntity.Email,
                    IsBlocked = userEntity.IsBlocked,
                    Login = userEntity.Login,
                    Name = userEntity.Name,
                    Password = userEntity.Password,
                    RoleId = userEntity.RoleId,
                    Status = userEntity.Status,
                    // GetAllAlbums = userEntity.GetAllAlbums
                };
                return userModel;
            }
            return null;
        }
        public int GetCountOfLikesForUser(Guid id)
        {
            int count = 0;
            IEnumerable<Photo> photoes = Binder.GetAllPhotoForUser(id);
            foreach (var photo in photoes)
            {

                count += photo.CountLikes;
            }
            return count;
        }
    }
}
