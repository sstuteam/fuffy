using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; private set; } // пароль в зашифрованном виде
        public string Email { get; set; }
        public Guid idUser;
        public string Name { get; set; }
        public string Cookies { get; set; }
        public int RoleId { get; set; }     //
        public string Status { get; set; }
        //public string sername;

        /// <summary>
        /// Свойство, показывающее заблокирован ли пользователь
        /// </summary>
        public bool IsBlocked { get; set; }

        ///// <summary>
        ///// Свойство показывающее имеет ли пользователь права администратора
        ///// </summary>
        //public bool IsAdmin { get; private set; }

        //public DateTime dateOfBirthday;  //Дата рождения
        public int countOfLikes; //Количество лайков, поставленных пользователю за все его фотографии
        public int countOfAlbum; //Количество альбомов
        /// <summary>
        /// Конструктор для регистрации нового пользователя
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        /// <param name="DateOfBirthday"></param>
        public User(string Login, string Password, string Email, string Name/*, DateTime DateOfBirthday*/)
        {
            this.Login = Login;
            this.Password = Password;
            this.Name = Name;
            this.Email = Email;
            //dateOfBirthday = DateOfBirthday;
            idUser = Guid.NewGuid();
            RoleId = 0;
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
        public User(Guid idUser, string Login, string Password, string Name, string Email,/* DateTime DateOfBirthday,*/ int countOfLikes, int countOfAlbums)
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

        public User(Guid idUser, string Login, string Password, string Name, string Email, string Cookies,string Status,int RoleId /*,DateTime DateOfBirthday*/)
        {
            this.Login = Login;
            this.Password = Password;
            this.Name = Name;
            this.Email = Email;
            //this.dateOfBirthday = DateOfBirthday;
            this.idUser = idUser;
            this.Cookies = Cookies;
            this.Status = Status;
            this.RoleId = RoleId;
        }

        public User()
        {
            idUser = Guid.NewGuid();
            RoleId = 0;
        }


    }
}
