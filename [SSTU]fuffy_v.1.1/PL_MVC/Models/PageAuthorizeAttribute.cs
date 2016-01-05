using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Models
{
    public class PageAuthorizeAttribute : AuthorizeAttribute
    {
        public int RoleID { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authCookie = httpContext.Request.Cookies["auth"];
            if (authCookie!=null)
            {
                User user = Binder.GetUser(authCookie.Value);
                return RoleID==user.RoleId;
            }
            return false;
        }
    }
}
