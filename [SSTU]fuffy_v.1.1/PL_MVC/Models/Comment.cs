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
        

        public Comment() { }          

        public static explicit operator Entities.Comment(Comment commentModel)
        {
            return new Entities.Comment()
            {
                commentId=commentModel.commentId,
                photoId=commentModel.photoId,
                text=commentModel.text,
                userId=commentModel.userId    
            };
        }

        public static explicit operator Comment(Entities.Comment commentEntitie)
        {
            return new Comment()
            {
                commentId=commentEntitie.commentId,
                photoId=commentEntitie.photoId,
                text=commentEntitie.text,
                userId=commentEntitie.userId
            };
        }
    }
}
