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
            if (user.passwordFirst == user.passwordRepeat)
            {
                user.password = user.passwordFirst;
                return bll.AddUser((Entities.User)user);
            }
            else
                return false;
            
        }
        
        public static bool CheckLogin(string Login)
        {
            return bll.CheckLogin(Login);
        }
    }
}
