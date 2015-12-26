using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public string login;
        public string password { get; private set; } // пароль в зашифрованном виде
        public string eMail;
        //public Guid idUser;
        public string name;
        //public string sername;


        public DateTime dateOfBirthday;  //Дата рождения
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
        public User(string Login, string Password, string Name, string EMail, DateTime DateOfBirthday)
        {
            login = Login;
            password = Password;
            name = Name;
            eMail = EMail;
            dateOfBirthday = DateOfBirthday;
            //idUser = Guid.NewGuid();
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
        public User(/*Guid IdUser,*/ string Login, string Password, string Name, string EMail, DateTime DateOfBirthday, int CountOfLikes, int CountOfAlbums)
        {
            login = Login;
            password = Password;
            name = Name;
            eMail = EMail;
            dateOfBirthday = DateOfBirthday;
            countOfAlbum = CountOfAlbums;
            countOfLikes = CountOfLikes;
            //idUser = IdUser;
        }


        public User(string Login, string Password, string EMail, string Name)
        {
            login = Login;            
            password = Password;
            eMail = EMail;
            name = Name;
        }

        /// <summary>
        /// Свойство, показывающее заблокирован ли пользователь
        /// </summary>
        public bool IsBlocked { get; set; }

        /// <summary>
        /// Свойство показывающее имеет ли пользователь права администратора
        /// </summary>
        public bool IsAdmin { get; private set; }
    }
}
