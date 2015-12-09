using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public class User
    {
        public string login;
        private string password; // пароль в зашифрованном виде
        public Guid idUser;
        public string name;
        public string sername;


        public DateTime dateOfBirthday;  //Дата рождения
        public int countOfLikes; //Количество лайков, поставленных пользователю за все его фотографии
        public int countOfAlbum; //Количество альбомов
        /// <summary>
        /// Конструктор для регистрации нового пользователя
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        /// <param name="Name"></param>
        /// <param name="Sername"></param>
        /// <param name="DateOfBirthday"></param>
        public User(string Login, string Password, string Name, string Sername, DateTime DateOfBirthday)
        {
            login = Login;
            password = Password;
            name = Name;
            sername = Sername;
            dateOfBirthday = DateOfBirthday;
            idUser = Guid.NewGuid();
        }
        /// <summary>
        /// Конструктор пользователя, информация о котором считана из базы
        /// </summary>
        /// <param name="IdUser"></param>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        /// <param name="Name"></param>
        /// <param name="Sername"></param>
        /// <param name="DateOfBirthday"></param>
        /// <param name="CountOfLikes"></param>
        /// <param name="CountOfAlbums"></param>
        public User(Guid IdUser, string Login, string Password, string Name, string Sername, DateTime DateOfBirthday, int CountOfLikes, int CountOfAlbums)
        {
            login = Login;
            password = Password;
            name = Name;
            sername = Sername;
            dateOfBirthday = DateOfBirthday;
            countOfAlbum = CountOfAlbums;
            countOfLikes = CountOfLikes;
            idUser = IdUser;
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
