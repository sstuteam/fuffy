using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class Logic : IBLL
    {
        IDAL dal;
        public Logic()
        {
            dal = new DBWork();
        }       

        public bool AddUser(User user)
        {
            if (CheckLogin(user.Login))
            {
                dal.Add(user);
                return true;
            }            
                return false;            
        }

        public bool CheckLogin(string Login)     //true - проверка пройдена, дубликат не найден,
        {                                        //false - такой логин уже существует
            return dal.GetAllUser().FirstOrDefault(x => x.Login == Login) == null;
        }

        public User GetUser(string cookie)   //*
        {
            var listUser = dal.GetAllUser();
            return listUser.FirstOrDefault(x => x.Cookies == cookie);
        }

        //public User GetUser(string cookie)   //**Посмотреть какая реальзация быстрее
        //{
        //    return dal.GetUser(cookie);
        //}

        public User GetUser(string Login, string Password)   //*Посмотреть какая реализация быстрее
        {
            var listUser = dal.GetAllUser();
            return listUser.FirstOrDefault(x => x.Login == Login && x.Password == Password);
        }

        //public User GetUser(string Login, string Password)   //*
        //{
        //    return dal.GetUser(Login, Password);
        //}
    }
}
