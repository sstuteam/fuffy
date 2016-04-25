using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Photo
    {
        public string Name { get; set; }
        public Guid IDPhoto;
        public Guid IDAlbum;
        public DateTime Data = DateTime.Now;
        public string Category { get; set; } //добавил
        public int CountLikes { get; set; }
        public string Spetification { get; set; }
        public byte[] Image { get; set; }

        public string ImageType { get; set; }
        /// <summary>
        /// Конструктор фотографии
        /// </summary>
        /// <param name="CorrentAlbum">Идентификатор текущего альбома, к которому привязана фотография</param>
        public Photo(Guid CorrentAlbum)
        {
            IDPhoto = Guid.NewGuid();
            IDAlbum = CorrentAlbum;
        }

        public Photo() { }
    }
}
