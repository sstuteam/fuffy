using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DAL
{
    public class DBWork : IDAL
    {
        private string ConnectionString;
        public DBWork()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["FuffyDB"].ConnectionString;
        }

        //public bool AddPhoto(Album album)
        //{
        //    using (SqlConnection c = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand com = new SqlCommand("INSERT INTO [dbo].[Album] ([ID],[IDAlbum],[Name],[Spetification]) VALUES (@ID,@IDAlbum,@Name,@Spetification)", c);
        //        com.Parameters.AddWithValue("@ID", album.IDUser);
        //        com.Parameters.AddWithValue("@IDAlbum", album.IDAlbum);
        //        com.Parameters.AddWithValue("@Name", album.Name);
        //        com.Parameters.AddWithValue("@Spetification", album.Spetification);
        //        c.Open();
        //        var a = com.ExecuteNonQuery();         //попробывать другой вариант
        //        return a > 0;
        //    }
        //}

        public bool Add(User user)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                user.Password = GetHashString(user.Password);
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
                SqlCommand com = new SqlCommand("INSERT INTO [dbo].[Photo] ([PhotoId],[AlbumId],[Name],[Spetification],[Image],[Data]) VALUES (@PhotoId,@AlbumId,@Name,@Spetification,@Image,@Data)", c);
                com.Parameters.AddWithValue("@PhotoId", image.IDPhoto);
                com.Parameters.AddWithValue("@AlbumId", image.IDAlbum);
                com.Parameters.AddWithValue("@Name", image.Name);
                com.Parameters.AddWithValue("@Spetification", image.Spetification);
                com.Parameters.AddWithValue("@Image", image.Image);
                com.Parameters.AddWithValue("@Data", image.Data);
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
                        Cookies = (string)reader["Cookies"],
                        /*Status = (string)reader["Status"],*/
                        /*RoleId = (int)reader["RoleID"],*/
                    };
                    if (reader["Status"] == System.DBNull.Value)
                    {
                        user.Status = null;
                    }
                    else
                    {
                        user.Status = (string)reader["Status"];
                        if (reader["RoleID"] == System.DBNull.Value)
                        {
                            user.RoleId = 0;
                        }
                        else
                        {
                            user.RoleId = (int)reader["RoleID"];
                            listUser.Add(user);
                        }
                    }
                }
                return listUser;
            }
        }
        public IEnumerable<Album> GetAllAlbums(Guid ID)
        {
            var listAlbum = new List<Album>();
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("SELECT [ID],[IDAlbum],[Name],[Spetification] FROM [dbo].[Album]", c);
                c.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Album album = new Album()
                    {
                        IDUser = (Guid)reader["ID"],
                        IDAlbum = (Guid)reader["IDAlbum"],
                        Name = (string)reader["Name"],
                        Spetification = (string)reader["Spetification"]
                    };
                    if (album.IDUser == ID)
                        listAlbum.Add(album);
                }
            }
            return listAlbum;
        }
        public IEnumerable<Album> GetAllAlbumsForUser(Guid iduser)
        {
            var listAlbums = GetAllAlbums(iduser);
            return listAlbums;
        }

        public User GetUser(Guid id)        //
        {                                         //
            var user = GetAllUser().FirstOrDefault(x => x.idUser == id);
            return user;
        }

        public User GetUser(string cookie)        //
        {                                         //
            throw new NotImplementedException();
        }

        public User GetUser(string Login, string Password)  //
        {                                                   //
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetComments(Guid id)
        {
            var listComment = new List<Comment>();
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("SELECT [Comment], [Likes], [CommentID], [PhotoId], [ID], [Date]  FROM [dbo].[Comment]", c);
                c.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {

                    Comment comment = new Comment()
                    {
                        CommentId=(Guid)reader["CommentID"],
                        PhotoId=(Guid)reader["PhotoId"],
                        Likes=(int)reader["Likes"],
                        Text=(string)reader["Comment"],
                        UserId=(Guid)reader["ID"],
                        Date=(DateTime)reader["Date"]
                    };
                    if (comment.PhotoId == id)
                    {
                        listComment.Add(comment);
                    }
                }
            }
            return listComment;
        }
        public bool AddComment(Comment comment)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("INSERT INTO [dbo].[Comment] ([Comment], [Likes], [CommentID], [PhotoId], [ID], [Date]) VALUES (@Text, @Likes, @CommentId, @PhotoId, @UserId, @Date)", c);
                com.Parameters.AddWithValue("@Text", comment.Text);
                com.Parameters.AddWithValue("@Likes", comment.Likes);
                com.Parameters.AddWithValue("@CommentId", comment.CommentId);
                com.Parameters.AddWithValue("@PhotoID", comment.PhotoId);
                com.Parameters.AddWithValue("@UserId", comment.UserId);
                com.Parameters.AddWithValue("@Date", comment.Date);
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
        public Photo GetPhoto(Guid idPhoto)
        {
            Photo photo = GetAllPhoto().FirstOrDefault(x => x.IDPhoto == idPhoto);
            return photo;
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
                var a = com.ExecuteNonQuery(); 
                return a > 0;
            }
        }



        public IEnumerable<Photo> GetAllPhoto()
        {
            var listPhoto = new List<Photo>();
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("SELECT  [Image], [Likes], [PhotoId],[AlbumId],[Name],[Spetification],[Data] FROM [dbo].[Photo]", c);
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
                        Spetification = (string)reader["Spetification"],
                        Image = (byte[])reader["Image"], 
                        Data = (DateTime)reader["Data"]                     
                    };
                    //if ((DateTime)reader["Data"] != DBNull.Value)
                    //{
                    //    photo.Data = (DateTime)reader["Data"]; //Чет пишет мол нельзя привести
                    //}
                    //else
                    //{
                    //    photo.Data = DateTime.MinValue;
                    //}
                    if(photo!=null)
                    listPhoto.Add(photo);

                }
            }
            return listPhoto;
        }


        public static string GetHashString(string Password)
        {
            //переводим строку в байт-массив 
            byte[] bytes = Encoding.Unicode.GetBytes(Password);

            //создаем объект для получения средств шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            Password = hash;

            return Password;
        }

        public IEnumerable<Photo> GetAllPhotoForUser(Guid idUser)
        {
            var albums = GetAllAlbums(idUser);
            var photoes = GetAllPhoto();
            foreach (var photo in photoes)
            {
                foreach (var album in albums)
                {
                    if (photo.IDAlbum == album.IDAlbum)
                    {
                        yield return photo;
                    }
                }
            }
        }
        public IEnumerable<Photo> GetAllPhotoForAlbum(Guid idAlbum)
        {
            return GetAllPhoto().Where(x=>x.IDAlbum==idAlbum).ToArray();
        }
        public Album GetAlbum(Guid idAlbum)
        {
            var album = GetAllAlbums().FirstOrDefault(x=>x.IDAlbum==idAlbum);
            return album;
        }
        /// <summary>
        /// Возвращение всех альбомов
        /// </summary>
        /// <returns></returns>
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
                    Album album = new Album()
                    {
                        IDUser = (Guid)reader["ID"],
                        IDAlbum = (Guid)reader["IDAlbum"],
                        Name = (string)reader["Name"],
                        Spetification = (string)reader["Spetification"]
                    };
                        listAlbum.Add(album);
                }
            }
            return listAlbum;
        }
        public int GetLikesComment(Guid CommentId,Guid PhotoId)
        {
            int likes = 0;
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                var comments = GetComments(PhotoId);
                SqlCommand com1 = new SqlCommand("SELECT [CommentID],[PhotoId],[Likes] FROM [dbo].[Comment]", c);
                c.Open();
                var reader1 = com1.ExecuteReader();
                while (reader1.Read())
                {
                    Comment comment1 = new Comment()
                    {
                        CommentId = (Guid)reader1["CommentID"],
                        Likes = (int)reader1["Likes"]
                    };
                    foreach (var comment in comments)
                    {
                        if (comment.CommentId == CommentId)
                        {
                            likes = comment1.Likes;
                        }
                    }
                }
                return likes;
            }
        }
        public int GetLikesPhoto(Guid Id)
        {
            int likes = 0;
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                var photoes = GetAllPhoto();
                SqlCommand com = new SqlCommand("SELECT [PhotoId],[Likes] FROM [dbo].[Photo]", c);
                c.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Like like = new Like()
                    {
                        PhotoId = (Guid)reader["PhotoId"],
                        Likes = (int)reader["Likes"]
                    };
                    foreach (var photo in photoes)
                    {
                        if (photo.IDPhoto == Id)
                        {
                            likes = like.Likes;
                        }
                    }
                }                
                return likes;
            }
        }
        public bool AddLikePhoto(Guid Id)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                var photoes = GetAllPhoto();
                SqlCommand com = new SqlCommand("SELECT [PhotoId],[Likes] FROM [dbo].[Photo]", c);
                c.Open();
                var reader = com.ExecuteReader();
                foreach (var photo in photoes)
                {
                    if (photo.IDPhoto == Id)
                    {
                        int likes = (int)reader["Likes"];
                        likes += 1;
                        SqlCommand com2 = new SqlCommand("INSERT INTO [dbo].[Photo] ([Likes]) VALUES (@likes)", c);
                    }
                    return false;
                }
            }
            return true;
        }
        public bool AddLikeComment(Guid CommentId,Guid PhotoId)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                var comments = GetComments(PhotoId);
                SqlCommand com = new SqlCommand("SELECT [CommentId],[Likes] FROM [dbo].[Comment]", c);
                c.Open();
                var reader = com.ExecuteReader();
                foreach (var comment in comments)
                {
                    if (comment.CommentId == CommentId)
                    {
                        int likes = (int)reader["Likes"];
                        likes += 1;
                        SqlCommand com2 = new SqlCommand("INSERT INTO [dbo].[Comment] ([Likes]) VALUES (@likes)", c);
                    }
                    return false;
                }
            }
            return true;
        }
        public bool DeleteLikePhoto(Guid Id)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                var photoes = GetAllPhoto();
                SqlCommand com = new SqlCommand("SELECT [PhotoId],[Likes] FROM [dbo].[Photo]", c);
                c.Open();
                var reader = com.ExecuteReader();
                foreach (var photo in photoes)
                {
                    if (photo.IDPhoto == Id)
                    {
                        int likes = (int)reader["Likes"];
                        likes -= 1;
                        SqlCommand com2 = new SqlCommand("INSERT INTO [dbo].[Photo] ([Likes]) VALUES (@likes)", c);
                    }
                    return false;
                }
            }
            return true;
        }
        public bool DeleteLikeComment(Guid CommentId,Guid PhotoId)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                var comments = GetComments(PhotoId);
                SqlCommand com = new SqlCommand("SELECT [CommentId],[Likes] FROM [dbo].[Comment]", c);
                c.Open();
                var reader = com.ExecuteReader();
                foreach (var comment in comments)
                {
                    if (comment.CommentId == CommentId)
                    {
                        int likes = (int)reader["Likes"];
                        likes -= 1;
                        SqlCommand com2 = new SqlCommand("INSERT INTO [dbo].[Comment] ([Likes]) VALUES (@likes)", c);
                    }
                    return false;
                }
            }
            return true;
        }
    }

}

