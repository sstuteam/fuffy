using System;
using System.Collections.Generic;
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

        public Comment() { }
        public Comment(string text, Guid commentId, Guid photoId, Guid userId)
        {
            this.Text = text;
            this.CommentId = commentId;
            this.PhotoId = photoId;
            this.UserId = userId;
        }

        public Comment(string text)
        {
            Text = text;
        }

        public static explicit operator Entities.Comment(Comment commentModel)
        {
            return new Entities.Comment()
            {
                CommentId=commentModel.CommentId,
                PhotoId=commentModel.PhotoId,
                Text=commentModel.Text,
                UserId=commentModel.UserId    
            };
        }

        public static explicit operator Comment(Entities.Comment commentEntitie)
        {
            return new Comment()
            {
                CommentId=commentEntitie.CommentId,
                PhotoId=commentEntitie.PhotoId,
                Text=commentEntitie.Text,
                UserId=commentEntitie.UserId
            };
        }
    }
}
