using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Comment
    {
        public Guid commentId;
        public string text;


        public Guid userId; // ид юзера, который написал коментарий    // Для таблицы
        public Guid photoId;// ид фото, к которому написан коммент     // связи 

        public Comment() { }
    }
}
