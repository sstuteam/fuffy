using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL
{
    public interface IBLL
    {
        bool AddUser(User user);
        bool CheckLogin(string Login);
        User GetUser(string cookie);
        User GetUser(string Login, string Password);
    }
}
