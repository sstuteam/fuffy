using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_MVC.Models
{
    public class Comment
    {
        public Guid commentId;
        public string text;


        public Guid userId; // ид юзера, который написал коментарий    // Для таблицы
        public Guid photoId;// ид фото, к которому написан коммент     // связи
        /// <summary>
        /// Конструктор создания нового коммента
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="IdUser"></param>
        /// <param name="IdPhoto"></param>
        public Comment(string Text, Guid UserId, Guid PhotoId)
        {
            commentId = Guid.NewGuid();
            text = Text;
            photoId = PhotoId;
            userId = UserId;
        }
        /// <summary>
        /// Конструктор коммента, считанного из базы
        /// </summary>
        /// <param name="CommentId"></param>
        /// <param name="Text"></param>
        /// <param name="UserId"></param>
        /// <param name="PhotoId"></param>
        public Comment(Guid CommentId, string Text, Guid UserId, Guid PhotoId)
        {
            commentId = CommentId;
            text = Text;
            userId = UserId;
            photoId = PhotoId;
        }

        public static explicit operator Entities.Comment(Comment commen)
        {
            return new Entities.Comment(commen.commentId, commen.text, 
                commen.userId, commen.photoId);
        }

        public static explicit operator Comment(Entities.Comment comment)
        {
            return new Comment(comment.commentId, comment.text,
                comment.userId, comment.photoId);
        }
    }
}
