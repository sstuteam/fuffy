using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_MVC.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; } // пароль будет зашифрованном виде
        public string PasswordFirst { get; set; }
        public string PasswordRepeat { get; set; }
        public Guid idUser;
        public string Name { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// Свойство, показывающее заблокирован ли пользователь
        /// </summary>
        public bool IsBlocked { get; set; }

        /// <summary>
        /// Свойство показывающее имеет ли пользователь права администратора
        /// </summary>
        public bool IsAdmin { get; private set; }

        //public DateTime dateOfBirthday;  //Дата рождения
        public int countOfLikes; //Количество лайков, поставленных пользователю за все его фотографии
        public int countOfAlbum; //Количество альбомов
        /// <summary>
        /// Конструктор для регистрации нового пользователя
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        /// <param name="Name"></param>
        /// <param name="EMail"></param>
        /// <param name="DateOfBirthday"></param>
        public User(string Login, string Password, string Name, string Email/*, DateTime DateOfBirthday*/)
        {
            this.Login = Login;
            this.Password = Password;
            this.Name = Name;
            this.Email = Email;
            //dateOfBirthday = DateOfBirthday;
            idUser = Guid.NewGuid();
        }
        /// <summary>
        /// Конструктор пользователя, информация о котором считана из базы
        /// </summary>
        /// <param name="IdUser"></param>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        /// <param name="Name"></param>
        /// <param name="EMail"></param>
        /// <param name="DateOfBirthday"></param>
        /// <param name="CountOfLikes"></param>
        /// <param name="CountOfAlbums"></param>
        public User(Guid idUser, string Login, string Password, string Name, string Email, /*DateTime DateOfBirthday,*/ int countOfLikes, int countOfAlbums)
        {
            this.Login = Login;
            this.Password = Password;
            this.Name = Name;
            this.Email = Email;
            //this.dateOfBirthday = DateOfBirthday;
            this.countOfAlbum = countOfAlbums;
            this.countOfLikes = countOfLikes;
            this.idUser = idUser;
        }
        

        public User() { }

        

        public static explicit operator Entities.User(User userModel)
        {
            return new Entities.User(userModel.idUser, userModel.Login, userModel.Password, 
                userModel.Name, userModel.Email, /*userModel.dateOfBirthday,*/ userModel.countOfLikes, 
                userModel.countOfAlbum);
        }

        public static explicit operator User(Entities.User userEntity)
        {
            return new User(userEntity.idUser, userEntity.Login, userEntity.Password, 
                userEntity.Name, userEntity.Email, /*userEntity.dateOfBirthday,*/
                userEntity.countOfLikes, userEntity.countOfAlbum);
        }
    }
}
