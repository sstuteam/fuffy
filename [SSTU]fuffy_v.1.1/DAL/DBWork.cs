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
        public bool Add(User user)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                user.Password = GetHashString(user.Password);
                SqlCommand com = new SqlCommand("INSERT INTO [dbo].[Login] ([ID],[Login],[Password],[Nick],[Email],[Cookies],[Avatar]) VALUES (@ID,@Login,@Password,@Nick,@Email,@Cookies,@Avatar)", c);
                com.Parameters.AddWithValue("@ID", user.idUser);
                com.Parameters.AddWithValue("@Login", user.Login);
                com.Parameters.AddWithValue("@Password", user.Password);
                com.Parameters.AddWithValue("@Nick", user.Name);
                com.Parameters.AddWithValue("@Email", user.Email);
                com.Parameters.AddWithValue("@Cookies", user.Cookies);
                com.Parameters.AddWithValue("@Avatar", user.Avatar);
                c.Open();
                var a = com.ExecuteNonQuery();
                return a > 0;
            }
        }
        public bool AddPhoto(Photo image)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("INSERT INTO [dbo].[Photo] ([PhotoId],[AlbumId],[Name],[Spetification],[Image],[Data],[Category]) VALUES (@PhotoId,@AlbumId,@Name,@Spetification,@Image,@Data,@Category)", c);
                com.Parameters.AddWithValue("@PhotoId", image.IDPhoto);
                com.Parameters.AddWithValue("@AlbumId", image.IDAlbum);
                com.Parameters.AddWithValue("@Name", image.Name);
                com.Parameters.AddWithValue("@Spetification", image.Spetification);
                com.Parameters.AddWithValue("@Image", image.Image);
                com.Parameters.AddWithValue("@Data", image.Data);
                com.Parameters.AddWithValue("@Category", image.Category);
                c.Open();
                var a = com.ExecuteNonQuery();
                return a > 0;
            }
        }
        public bool EditAvatar(Guid UserId, Photo image)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                        SqlCommand com = new SqlCommand("UPDATE [dbo].[Login] SET [Avatar]=@Avatar WHERE ID = @UserId", c);
                com.Parameters.AddWithValue("@Avatar", image.Image);
                com.Parameters.AddWithValue("@UserId", UserId);         
                        c.Open();
                        var a = com.ExecuteNonQuery();
                        return a > 0;
                
            }
        }
        public bool GetAvatar(Guid UserId)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com1 = new SqlCommand("SELECT [Avatar] FROM [dbo].[Login]", c);
                c.Open();
                var reader = com1.ExecuteReader();
                while (reader.Read())
                {
                    var user = GetUser(UserId);
                    user.Avatar = (byte[])reader["Avatar"];
                }
            }
            return true;
        }
        public IEnumerable<User> GetAllUser()
        {
            var listUser = new List<User>();
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("SELECT [ID],[Login],[Password],[Email],[Nick],[Cookies],[Status],[RoleID],[Avatar] FROM [dbo].[Login]", c);
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
                        Avatar=(byte[])reader["Avatar"]
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
            return GetComments().Where(item => item.PhotoId == id);
        }
        public bool DeleteComment(Guid commentId)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand comComent = new SqlCommand("DELETE FROM [dbo].[Comment] WHERE CommentID=@commentId", c);
                comComent.Parameters.AddWithValue("@commentId", commentId);
                c.Open();
                var b = comComent.ExecuteNonQuery();
                return b > -1 ;
            }
        }       

        public bool DeletePhoto(Guid id)  /////////////////////////////////////////////////////////////////////////////////////
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand comComent = new SqlCommand("DELETE FROM [dbo].[Comment] WHERE PhotoId=@PhotoId" , c);
                comComent.Parameters.AddWithValue("@PhotoId", id);
                SqlCommand comLike = new SqlCommand("DELETE FROM [dbo].[LikesForPhoto] WHERE PhotoId=@PhotoId", c);
                comLike.Parameters.AddWithValue("@PhotoId", id);//хз как то не так лайки работают
                SqlCommand comPhoto = new SqlCommand("DELETE FROM [dbo].[Photo] WHERE PhotoId=@PhotoId", c);
                comPhoto.Parameters.AddWithValue("@PhotoId", id);
                c.Open();
                var a = comLike.ExecuteNonQuery();
                var b = comComent.ExecuteNonQuery();
                var d = comPhoto.ExecuteNonQuery();
                return (a > -1 && b>-1&&d>-1);
            }            
           
        }
        public bool DeleteAllUserAlbums(Guid id)
        {
            var listAlbums = GetAllAlbumsForUser(id);
            int count = listAlbums.Count();
            int c = 0;          
            foreach (var item in listAlbums)
            {
                c++;          
                 DeleteAlbum(item.IDAlbum);
            }
            if (c == count)
                return true;
            else return false;
            //
        }
        public bool DeleteAlbum(Guid Albumid)//////////////////////////////////////////////////////////////////////////////////////
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("DELETE FROM [dbo].[Album] WHERE IDAlbum=@IDAlbum", c);
                com.Parameters.AddWithValue("@IDAlbum", Albumid);
                c.Open();
                var reader = com.ExecuteNonQuery();
                return (reader > -1);
                }
            }
        public bool DeleteUser(Guid UserID)//////////////////////////////////////////////////////////////////////////////////////
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("DELETE FROM [dbo].[Login] WHERE ID=@ID", c);
                com.Parameters.AddWithValue("@ID", UserID);
                c.Open();
                var reader = com.ExecuteNonQuery();
                return (reader > -1);
            }
        }

        public IEnumerable<Comment> GetComments()
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
                        listComment.Add(comment);
                    
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
            if (name == null) { name = ""; }
            if (fragment == null) { fragment = ""; }
            return GetAllPhoto().Where(x => x.Spetification.Contains(fragment) && x.Name == name);
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
                SqlCommand com = new SqlCommand("SELECT  [Image], [Likes], [PhotoId],[AlbumId],[Name],[Spetification],[Data],[Category] FROM [dbo].[Photo]", c);
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
                        Data = (DateTime)reader["Data"],
                        Category=(string)reader["Category"]        
                    };
                   // photo.Category = reader["Category"].ToString();
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

            //создаем объект для получения средств шиAрования  
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
            return GetAllPhoto().Where(x => x.IDAlbum == idAlbum);
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

        public int GetLikesPhoto(Guid Id)
        {
            var photo = GetAllPhoto().FirstOrDefault(item => item.IDPhoto == Id); //можно было сократить
            if (photo != null)
            {
                return photo.CountLikes;
            }
            else return 0;
        }
        public IEnumerable<Like> GetAllLikesFromDB()
        {
            List<Like> likes = new List<Like>();
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("SELECT [UserId], [PhotoId] FROM [dbo].[LikesForPhoto]", c);
                c.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Like like = new Like()
                    {
                        PhotoId = (Guid)reader["PhotoId"],
                        UserId = (Guid)reader["UserId"]
                    };
                    likes.Add(like);
                }
            }
            return likes;
        }
        public bool AddLikesToDB(Like like)
        {
            var likes = GetAllLikesFromDB();
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand comLike = new SqlCommand("INSERT INTO [dbo].[LikesForPhoto] (UserId, PhotoId) VALUES (@UserId, @PhotoId)", c);
                comLike.Parameters.AddWithValue("@UserId", like.UserId);
                comLike.Parameters.AddWithValue("@PhotoId", like.PhotoId);
                c.Open();
                var a = comLike.ExecuteNonQuery();                       //НУЖНО ПЕРЕХВАТИТЬ ОШИБКУ; ПРОВЕРИТЬ В AddLikePhoto
                return a == 1;
            }
        }
        public bool DeleteLikesToDB(Like like)
        {
            var likes = GetAllLikesFromDB();
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand comLike = new SqlCommand("DELETE FROM [dbo].[LikesForPhoto] WHERE UserId=@UserId AND PhotoId=@PhotoId", c);
                comLike.Parameters.AddWithValue("@UserId", like.UserId);
                comLike.Parameters.AddWithValue("@PhotoId", like.PhotoId);
                c.Open();
                var a = comLike.ExecuteNonQuery();                       //НУЖНО ПЕРЕХВАТИТЬ ОШИБКУ; ПРОВЕРИТЬ В AddLikePhoto
                return a == 1;
            }
        }
        public bool AddLikePhoto(Guid Id, Like like)
        {
            var image = GetAllPhoto().FirstOrDefault(item => item.IDPhoto == Id);
            int likes = GetLikesPhoto(Id); //все лайки. С помощью этого можно проверить. Но фигня
            Like likesDB = GetAllLikesFromDB().FirstOrDefault(x=>x.PhotoId==like.PhotoId && x.UserId==like.UserId);
            if (likesDB == null)
            {
                
                    AddLikesToDB(like);
                    using (SqlConnection c = new SqlConnection(ConnectionString))
                    {
                        likes += 1;

                        SqlCommand com = new SqlCommand("UPDATE [dbo].[Photo] SET [Likes]=@likes WHERE PhotoId=@PhotoId", c);
                        com.Parameters.AddWithValue("@PhotoId", image.IDPhoto);
                        com.Parameters.AddWithValue("@AlbumId", image.IDAlbum);
                        com.Parameters.AddWithValue("@Name", image.Name);
                        com.Parameters.AddWithValue("@Spetification", image.Spetification);
                        com.Parameters.AddWithValue("@Image", image.Image);
                        com.Parameters.AddWithValue("@likes", likes);
                        c.Open();
                        var a = com.ExecuteNonQuery();
                        return a > 0;
                    }
                }
            
            else
            {
                DeleteLikePhoto(Id);
                DeleteLikesToDB(like);
            }
            return true;
          }
        
        public bool AddLikeComment(Guid Id)
        {
            var comment = GetComments(Id).FirstOrDefault(item => item.CommentId == Id);
            int likes = GetLikesPhoto(Id);
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                likes += 1;

                SqlCommand com = new SqlCommand("UPDATE [dbo].[Comment] SET [Likes]=@likes WHERE CommentId=@CommentId", c);
                com.Parameters.AddWithValue("@CommentId", comment.CommentId);
                com.Parameters.AddWithValue("@Date", comment.Date);
                com.Parameters.AddWithValue("@likes", likes);
                com.Parameters.AddWithValue("@PhotoId", comment.PhotoId);
                com.Parameters.AddWithValue("@Text", comment.Text);
                com.Parameters.AddWithValue("@UserId", comment.UserId);
                c.Open();
                var a = com.ExecuteNonQuery();
                return a > 0;
            }
        }
        public bool DeleteLikePhoto(Guid Id)
        {
            var image = GetAllPhoto().FirstOrDefault(item => item.IDPhoto == Id);
            int likes = GetLikesPhoto(Id);
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                likes -= 1;

                SqlCommand com = new SqlCommand("UPDATE [dbo].[Photo] SET [Likes]=@likes WHERE PhotoId=@PhotoId", c);
                com.Parameters.AddWithValue("@PhotoId", image.IDPhoto);
                com.Parameters.AddWithValue("@AlbumId", image.IDAlbum);
                com.Parameters.AddWithValue("@Name", image.Name);
                com.Parameters.AddWithValue("@Spetification", image.Spetification);
                com.Parameters.AddWithValue("@Image", image.Image);
                com.Parameters.AddWithValue("@likes", likes);
                c.Open();
                var a = com.ExecuteNonQuery(); //хз, зачем это
                return a > 0;
            }
        }
        public bool DeleteLikeComment(Guid Id)
        {
            var comment = GetComments(Id).FirstOrDefault(item => item.CommentId == Id);
            int likes = GetLikesPhoto(Id);
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                likes -= 1;

                SqlCommand com = new SqlCommand("UPDATE [dbo].[Comment] SET [Likes]=@likes WHERE CommentId=@CommentId", c);
                com.Parameters.AddWithValue("@CommentId", comment.CommentId);
                com.Parameters.AddWithValue("@Date", comment.Date);
                com.Parameters.AddWithValue("@likes", likes);
                com.Parameters.AddWithValue("@PhotoId", comment.PhotoId);
                com.Parameters.AddWithValue("@Text", comment.Text);
                com.Parameters.AddWithValue("@UserId", comment.UserId);
                c.Open();
                var a = com.ExecuteNonQuery();
                return a > 0;
            }
        }

        public int GetLikesComment(Guid Id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("UPDATE [dbo].[Login] SET [Nick]=@Name,[RoleId]=@RoleId,[Status]=@Status,[Password]=@Password,[Email]=@Email WHERE [ID]=@ID", c);
                //com.Parameters.AddWithValue("@Login", user.Login);
                com.Parameters.AddWithValue("@Name", user.Name);
                com.Parameters.AddWithValue("@RoleId", user.RoleId);
                com.Parameters.AddWithValue("@Status", user.Status);
                //com.Parameters.AddWithValue("@IsBlocked", user.IsBlocked);
                //com.Parameters.AddWithValue("@Hobbies", user.Hobbies);
                com.Parameters.AddWithValue("@Password", user.Password);
                com.Parameters.AddWithValue("@Email", user.Email);
                com.Parameters.AddWithValue("@ID", user.idUser);
                c.Open();
                return com.ExecuteNonQuery() == 1;
            }
        }
        public bool EditComment(Comment comment)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("UPDATE [dbo].[Comment] SET [Comment]=@Comment, [Date]=@Date WHERE CommentId=@CommentId", c);
                com.Parameters.AddWithValue("@CommentId", comment.CommentId);
                com.Parameters.AddWithValue("@Date", comment.Date);
                com.Parameters.AddWithValue("@Comment", comment.Text);
                c.Open();
                return com.ExecuteNonQuery() == 1;
            }
        }

        public bool EditPhoto(Photo photo)
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand("UPDATE [dbo].[Photo] SET [Spetification]=@Specification, [Data]=@Date, [Category]=@Category, [Name]=@Name WHERE PhotoId=@PhotoId", c);
                com.Parameters.AddWithValue("@PhotoId", photo.IDPhoto);
                if (photo.Spetification == null)
                {
                    com.Parameters.AddWithValue("@Specification", DBNull.Value);
                }
                else {
                    com.Parameters.AddWithValue("@Specification", photo.Spetification);
                }
                com.Parameters.AddWithValue("@Date", photo.Data);
                //com.Parameters.AddWithValue("@AlbumId", photo.IDAlbum);
                com.Parameters.AddWithValue("@Category", photo.Category);
                com.Parameters.AddWithValue("@Name", photo.Name);
                c.Open();
                return com.ExecuteNonQuery() == 1;
            }
        }

        //public bool Delete
        public bool CreateAdmin(User user)//////////
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {

                SqlCommand com = new SqlCommand("UPDATE [dbo].[Login] SET RoleId=@RoleId WHERE ID=@ID", c);               
                com.Parameters.AddWithValue("@RoleId", user.RoleId);              
                com.Parameters.AddWithValue("@ID", user.idUser);
                c.Open();
                var a = com.ExecuteNonQuery();
                return (a >- 1);               
            }
        }
        public bool BlockUser(User user)//////////
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {

                SqlCommand com = new SqlCommand("UPDATE [dbo].[Login] SET RoleId=@RoleId WHERE ID=@ID", c);
                com.Parameters.AddWithValue("@RoleId", user.RoleId);
                com.Parameters.AddWithValue("@ID", user.idUser);
                c.Open();
                var a = com.ExecuteNonQuery();
                return (a > -1);
            }
        }
        public bool UnBlockUser(User user)//////////
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {

                SqlCommand com = new SqlCommand("UPDATE [dbo].[Login] SET RoleId=@RoleId WHERE ID=@ID", c);
                com.Parameters.AddWithValue("@RoleId", user.RoleId);
                com.Parameters.AddWithValue("@ID", user.idUser);
                c.Open();
                var a = com.ExecuteNonQuery();
                return (a > -1);
            }
        }
        public bool CreateModerator(User user)//////////
        {
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {

                SqlCommand com = new SqlCommand("UPDATE [dbo].[Login] SET RoleId=@RoleId WHERE ID=@ID", c);
                com.Parameters.AddWithValue("@RoleId", user.RoleId);
                com.Parameters.AddWithValue("@ID", user.idUser);
                c.Open();
                var a = com.ExecuteNonQuery();
                return (a > -1);
            }
        }

    }

}

