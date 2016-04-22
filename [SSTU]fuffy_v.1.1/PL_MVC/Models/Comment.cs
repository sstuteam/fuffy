using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_MVC.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Text { get; set; }

        public int Like { get; set; }

        public Guid UserId { get; set; } // ид юзера, который написал коментарий    // Для таблицы
        public Guid PhotoId { get; set; }// ид фото, к которому написан коммент     // связи 
        
        public DateTime Date { get; set; }

        public Comment() { }
        
        public static implicit operator Entities.Comment(Comment CommentModel)
        {
            if (CommentModel != null)
            {
                Entities.Comment commentEntities = new Entities.Comment()
                {
                    UserId=CommentModel.UserId,
                    PhotoId=CommentModel.PhotoId,
                    CommentId=CommentModel.CommentId,
                    Likes=CommentModel.Like,
                    Text=CommentModel.Text
                };
                return commentEntities;
            }
            return null;
        }

        public static implicit operator Comment(Entities.Comment CommentEntities)
        {
            if (CommentEntities != null)
            {
                Comment commentModel = new Comment()
                {
                    CommentId=CommentEntities.CommentId,
                    Like=CommentEntities.Likes,
                    PhotoId=CommentEntities.PhotoId,
                    Text=CommentEntities.Text,
                    UserId=CommentEntities.UserId
                };
                return commentModel;
            }
            return null;
        }
    }
}
