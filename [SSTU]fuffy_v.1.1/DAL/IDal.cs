using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public interface IDAL
    {
        bool Add(User user);
        List<User> GetAllUser();
    }
}
