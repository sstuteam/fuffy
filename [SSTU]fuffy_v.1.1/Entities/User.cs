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
        public string Password { get; set; } // пароль в зашифрованном виде
        public string Email { get; set; }
        public Guid idUser;
        public string Name { get; set; }
        public string Hobbies { get; set; }
        public string Cookies { get; set; }
        public int RoleId { get; set; }     //
        public string Status { get; set; }
        public byte[] Avatar { get; set; }
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
        public int countOfLikes=0; //Количество лайков, поставленных пользователю за все его фотографии
        public int countOfAlbum=0; //Количество альбомов         
        
        public User()
        {
            idUser = Guid.NewGuid();
            RoleId = 0;
        } 
    }
}
