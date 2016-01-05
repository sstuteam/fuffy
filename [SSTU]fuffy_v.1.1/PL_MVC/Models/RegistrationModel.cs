using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_MVC.Models
{
    public class RegistrationModel
    {                                           //сделать чтобы эти фильтры работали
        [Required(ErrorMessage = "*")]
        public string Login { get; set; }
        [Required(ErrorMessage = "*")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", 
            ErrorMessage = "Не корректный Email")]  // регулярка для валидации почты
        public string Email { get; set; }
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        public string Password { get; set; }
        [Required(ErrorMessage = "*")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordRepeat { get; set; }
    }
}
