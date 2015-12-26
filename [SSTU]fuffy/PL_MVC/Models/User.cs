using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_MVC.Models
{
    public class User
    {
        public string login { get; set; }
        public string password { get; set; } // пароль будет зашифрованном виде
        public string passwordFirst { get; set; }
        public string passwordRepeat { get; set; }
        //public Guid idUser;
        public string name { get; set; }
        public string eMail { get; set; }


        public DateTime dateOfBirthday;  //Дата рождения
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


        public User() { }
        
        //public User(string Login,string PasswordFirst,string PasswordRepeat,string EMail, string Name)
        //{
        //    login = Login;
        //    passwordFirst = PasswordFirst;
        //    passwordRepeat = PasswordRepeat;
        //    eMail = EMail;
        //    name = Name;
        //}

        /// <summary>
        /// Свойство, показывающее заблокирован ли пользователь
        /// </summary>
        public bool IsBlocked { get; set; }

        /// <summary>
        /// Свойство показывающее имеет ли пользователь права администратора
        /// </summary>
        public bool IsAdmin { get; private set; }

        public static explicit operator Entities.User(User userModel)
        {
            return new Entities.User(/*userModel.idUser,*/ userModel.login, userModel.password, 
                userModel.name, userModel.eMail, userModel.dateOfBirthday, userModel.countOfLikes, 
                userModel.countOfAlbum);
        }

        public static explicit operator User(Entities.User userEntity)
        {
            return new User(/*userEntity.idUser,*/ userEntity.login, userEntity.password, 
                userEntity.name, userEntity.eMail, userEntity.dateOfBirthday,
                userEntity.countOfLikes, userEntity.countOfAlbum);
        }
    }
}
