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
                SqlCommand com = new SqlCommand("INSERT INTO [dbo].[Profile] ([login],[password],[eMail],[name]) VALUES (@login,@password,@eMail)", c);
                com.Parameters.AddWithValue("@login", user.login);
                com.Parameters.AddWithValue("@password", user.password);
                com.Parameters.AddWithValue("@name", user.name);
                c.Open();
                var a = com.ExecuteNonQuery();
                return a != 0;
            }          
        }

        public List<User> GetAllUser()
        {
            var listUser = new List<User>();          
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("SELECT [login],[password],[eMail],[name] FROM [dbo].[User]", c);
                c.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User((string)reader["login"], (string)reader["password"], (string)reader["eMail"],(string)reader["name"]);
                    listUser.Add(user);
                }
            }
            return listUser;
        }
    }
}
