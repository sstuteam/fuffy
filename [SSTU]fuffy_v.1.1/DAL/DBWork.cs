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

        public bool Add(Album album)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("INSERT INTO [dbo].[Album] ([ID],[IDAlbum],[Name],[Spetification]) VALUES (@ID,@IDAlbum,@Name,@Spetification)",c);
                com.Parameters.AddWithValue("@ID",album.IDUser);
                com.Parameters.AddWithValue("@IDAlbum",album.IDAlbum);
                com.Parameters.AddWithValue("@Name",album.Name);
                com.Parameters.AddWithValue("@Spetification",album.Spetification);
                c.Open();
                var a = com.ExecuteNonQuery();         //попробывать другой вариант
                return a > 0;
            }
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
        public bool Add(Photo image)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("INSERT INTO [dbo].[Photo] ([PhotoId],[AlbumId],[Name],[Spetification],[Image]) VALUES (@PhotoId,@AlbumId,@Name,@Spetification,@Image)", c);
                com.Parameters.AddWithValue("@PhotoId", image.IDPhoto);
                com.Parameters.AddWithValue("@AlbumId", image.IDAlbum);
                com.Parameters.AddWithValue("@Name", image.Name);
                com.Parameters.AddWithValue("@Spetification", image.Spetification);
                com.Parameters.AddWithValue("@Image", image.Image); 
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
                SqlCommand com = new SqlCommand("SELECT [ID],[Login],[Password],[Email],[Nick],[Cookies],[Status],[RoleID] FROM [dbo].[Login]", c);
                c.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User()
                    {
                        idUser=(Guid)reader["ID"],
                        Login=(string)reader["Login"],
                        Password=(string)reader["Password"],
                        Name=(string)reader["Nick"],
                        Email=(string)reader["Email"],
                        Cookies=(string)reader["Cookies"],
                        Status=(string)reader["Status"],
                        RoleId=(int)reader["RoleID"],                                    
                    };
                    listUser.Add(user);
                }
            }
            return listUser;
        }
        public List<Album> GetAllAlbums()
        {
            var listAlbum = new List<Album>();
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("SELECT [ID],[IDAlbum],[Name],[Spetification] FROM [dbo].[Album]", c);
                c.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Album album = new Album() {
                        IDUser= (Guid)reader["ID"],
                        IDAlbum = (Guid)reader["IDAlbum"],
                        Name=(string)reader["Name"],
                        Spetification=(string)reader["Spetification"]
                    };
                    listAlbum.Add(album);
                }
            }
            return listAlbum;
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
