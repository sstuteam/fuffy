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
                SqlCommand com = new SqlCommand("INSERT INTO [dbo].[Profile] ([UserID],[Login],[Password],[Name],[Email]) VALUES (@UserID,@Login,@Password,@Name,@Email)", c);
                com.Parameters.AddWithValue("@UserID", user.idUser);
                com.Parameters.AddWithValue("@Login", user.Login);
                com.Parameters.AddWithValue("@Password", user.Password);
                com.Parameters.AddWithValue("@Name", user.Name);
                com.Parameters.AddWithValue("@Email", user.Email);
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
                SqlCommand com = new SqlCommand("SELECT [UserID],[Login],[Password],[Email],[Name] FROM [dbo].[Profile]", c);
                c.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User((Guid)reader["UserID"],(string)reader["Login"], (string)reader["Password"], (string)reader["Name"],(string)reader["Email"]);
                    listUser.Add(user);
                }
            }
            return listUser;
        }
    }
}
