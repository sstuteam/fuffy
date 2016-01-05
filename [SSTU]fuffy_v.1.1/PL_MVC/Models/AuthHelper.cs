using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PL_MVC.Models
{
    public static class AuthHelper
    {
        /// <summary>
        /// Вход пользователя, запись куки
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="cookies"></param>
        public static void LogInUser(HttpContextBase httpContext, string cookies)
        {
            var cookie = new HttpCookie("auth")
            {
                Value = cookies,
                Expires = DateTime.Now.AddYears(1)
            };
            httpContext.Response.Cookies.Add(cookie);
        }
        /// <summary>
        /// Выход пользователя, установление недействительного куки
        /// </summary>
        /// <param name="httpContext"></param>
        public static void LogOffUser(HttpContextBase httpContext)
        {
            if(httpContext.Request.Cookies["auth"]!=null)
            {
                var cookie = new HttpCookie("auth")
                {
                    Expires = DateTime.Now.AddDays(-1),
                };
                httpContext.Response.Cookies.Add(cookie);
            }
        }
        /// <summary>
        /// Вернуть пользователя по куки
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static User GetUser(HttpContextBase httpContext)
        {
            var authCookie = httpContext.Request.Cookies["auth"];
            if(authCookie!=null)
            {
                User user = Binder.GetUser(authCookie.Value);
                return user;
            }
            return null;
        }
        /// <summary>
        /// Проверка на авторизованность
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static bool IsAuthenticated(HttpContextBase httpContext)
        {
            var authCookue = httpContext.Request.Cookies["auth"];
            if (authCookue != null)
            {
                User user = Binder.GetUser(authCookue.Value);
                return user != null;
            }
            return false;
        }
    }
}
