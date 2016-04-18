using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Text { get; set; }

        public int Like { get; set; }

        public Guid UserId { get; set; } // ид юзера, который написал коментарий    // Для таблицы
        public Guid PhotoId { get; set; }// ид фото, к которому написан коммент     // связи 

        public DateTime Date = DateTime.Now;
        public Comment() { }
    }
}
