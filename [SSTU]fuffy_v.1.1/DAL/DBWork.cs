using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class DBWork : IDAL
    {
        private string ConnectionString;
        public DBWork()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["FuffyDB"].ConnectionString;
        }

        public bool Add(User user)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("INSERT INTO [dbo].[Login] ([ID],[Login],[Password],[Nick],[Email],[Cookies]) VALUES (@ID,@Login,@Password,@Nick,@Email,@Cookies)", c);
                com.Parameters.AddWithValue("@ID", user.idUser);
                com.Parameters.AddWithValue("@Login", user.Login);
                com.Parameters.AddWithValue("@Password", user.Password);
                com.Parameters.AddWithValue("@Nick", user.Name);
                com.Parameters.AddWithValue("@Email", user.Email);
                com.Parameters.AddWithValue("@Cookies", user.Cookies);
                c.Open();
                var a = com.ExecuteNonQuery();
                return a > 0;
            }
        }

        public List<User> GetAllUser()
        {
            var listUser = new List<User>();
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("SELECT [ID],[Login],[Password],[Email],[Nick],[Cookies],[Status] FROM [dbo].[Login]", c);
                c.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User((Guid)reader["ID"], (string)reader["Login"], (string)reader["Password"], (string)reader["Nick"], (string)reader["Email"],(string)reader["Cookies"],(string)reader["Status"]);
                    listUser.Add(user);
                }
            }
            return listUser;
        }

        public User GetUser(string cookie)        //
        {                                         //
            throw new NotImplementedException();
        }

        public User GetUser(string Login, string Password)  //
        {                                                   //
            throw new NotImplementedException();
        }
    }
}
