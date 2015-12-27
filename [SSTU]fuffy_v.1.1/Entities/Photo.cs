using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Photo
    {
        public string Name; //имя фото
        public Guid PhotoId; // идентификатор фото
        public Guid AlbumId; // идентификатор альбома
        /// <summary>
        /// Конструктор фотографии
        /// </summary>
        /// <param name="CorrentAlbum">Идентификатор текущего альбома, к которому привязана фотография</param>
        public Photo(Guid CorrentAlbum)
        {
            PhotoId = Guid.NewGuid();
            AlbumId = CorrentAlbum;
        }
        /// <summary>
        /// Метод переименования фото
        /// </summary>
        /// <param name="newname">Новое имя фото</param>
        public void Rename(string newname)
        {
            Name = newname;
        }
        /// <summary>
        /// Метод переноса фото в новый альбом
        /// </summary>
        /// <param name="NewAlbumId"></param>
        public void ChangeAlbum(Guid newAlbumId)
        {
            AlbumId = newAlbumId;
        }
    }
}
