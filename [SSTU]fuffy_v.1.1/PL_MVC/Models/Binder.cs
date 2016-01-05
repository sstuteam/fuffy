using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace PL_MVC.Models
{    
    public static class Binder
    {
        public static IBLL bll = new Logic();
        public static bool AddUser(User user)
        {            
            return bll.AddUser((Entities.User)user);
        }        
        
        public static bool CheckLogin(string Login)
        {
            return bll.CheckLogin(Login);
        }
        public static User GetUser(string cookie)
        {
            return bll.GetUser(cookie);
        }

        public static User GetUser(string Login,string Password)
        {
            return bll.GetUser(Login, Password);
        }
    }
}
