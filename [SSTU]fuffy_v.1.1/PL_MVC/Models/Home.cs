using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_MVC.Models
{
    public class Home
    {
        [Required(ErrorMessage = "*")]
        public string Login { get; set; }
        [Required(ErrorMessage = "*")]
        public string Password { get; set; }
        public bool ErrorAuth = false;
        public Home() { }
        public Home (bool ErrorAuth)
        {
            this.ErrorAuth = ErrorAuth;
        }
    }
}
