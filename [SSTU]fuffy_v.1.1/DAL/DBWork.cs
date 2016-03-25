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

        public bool AddPhoto(Album album)
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
        public bool AddPhoto(Photo image)
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
        
        public IEnumerable<User> GetAllUser()
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
                        idUser = (Guid)reader["ID"],
                        Login = (string)reader["Login"],
                        Password = (string)reader["Password"],
                        Name = (string)reader["Nick"],
                        Email = (string)reader["Email"],
                        Cookies = (string)reader["Cookies"] ,
                        /*Status = (string)reader["Status"],*/
                        /*RoleId = (int)reader["RoleID"],*/
                    };
                    if (reader["Status"] == System.DBNull.Value)
                    { user.Status = null; }
                    else user.Status = (string)reader["Status"];
                    if (reader["RoleID"] == System.DBNull.Value)
                    { user.RoleId = 0; }
                    else user.RoleId = (int)reader["RoleID"];
                    listUser.Add(user);
                }
            }
            return listUser;
        }
        public IEnumerable<Album> GetAllAlbums()
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

        public IEnumerable<Comment> GetComments()
        {
            var listComment = new List<Comment>();
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("SELECT Comment, Likes FROM [dbo].[Comments]", c);
                c.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Comment comment = new Comment((string)reader["Comment"], (Guid)reader["CommentID"], (Guid)reader["PhotoID"], (Guid)reader["ID"]);
                    listComment.Add(comment);
                }
            }
            return listComment;
        }
        public bool AddComment(Comment comment)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("INSERT INTO [dbo].[Comment] ([Comment], [Likes], [CommentID], [PhotoId]) VALUES (@Comment, @Likes, @CommentID, @PhotoId)", c);
                com.Parameters.AddWithValue("@Comment", comment.Text);
                com.Parameters.AddWithValue("@Likes", comment.Like);
                com.Parameters.AddWithValue("@CommentID", comment.CommentId);
                com.Parameters.AddWithValue("@PhotoID", comment.PhotoId);
                com.Parameters.AddWithValue("@ID", comment.UserId);
                c.Open();
                return com.ExecuteNonQuery() > 1;
            }
        }
        public IEnumerable<Photo> Search(string name, string fragment)
        {
            IEnumerable<Photo> listPhoto = GetAllPhoto();
            var result = new List<Photo>();
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                foreach (var item in listPhoto)
                {
                    if (name == item.Name && item.Spetification.Contains(fragment))
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public bool AddAlbum(Album album)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("INSERT INTO [dbo].[Album] ([Name], [ID], [IDAlbum], [Spetification]) VALUES (@Name, @ID, @IDAlbum, @Spetification)", c);
                com.Parameters.AddWithValue("@Name", album.Name);
                com.Parameters.AddWithValue("@ID", album.IDUser);
                com.Parameters.AddWithValue("@IDAlbum", album.IDAlbum);
                com.Parameters.AddWithValue("@Spetification", album.Spetification);
                c.Open();
            }
                /*throw new NotImplementedException();*/
                return true;
        }

        public IEnumerable<Photo> GetAllPhoto()
        {
            var listPhoto = new List<Photo>();
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("SELECT  ([PhotoId],[AlbumId],[Name],[Spetification],[Image]) FROM [dbo].[Photo]", c);
                c.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Photo photo = new Photo()
                    {
                        IDPhoto = (Guid)reader["PhotoId"],
                        IDAlbum = (Guid)reader["AlbumId"],
                        Name = (string)reader["Name"],
                        CountLikes = (int)reader["Likes"],
                        Spetification = (string)reader["Name"],
                        Image = (byte[])reader["Image"]
                    };
                    listPhoto.Add(photo);
                }
            }
            return listPhoto;
        }
    }
}
