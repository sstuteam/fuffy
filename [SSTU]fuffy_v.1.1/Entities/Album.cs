using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Album
    {
        public string Name;  //имя альбома
        public Guid AlbumId;  //идентификатор альбома
        public List<Guid> PhotoId;  //идентификаторы фото, принадлежащих альбому
        /// <summary>
        /// Конструктор нового альбома
        /// </summary>
        /// <param name="name">Имя альбома</param>
        public Album(string name)
        {
            Name = name;
            AlbumId = Guid.NewGuid();
            PhotoId = new List<Guid>();

        }
        /// <summary>
        /// Метод добавления фото в альбом
        /// </summary>
        /// <param name="Photo">идентификатор фото</param>
        public void Add(Guid Photo)
        {
            PhotoId.Add(Photo);
        }
        /// <summary>
        /// метод удаления фото из альбома
        /// </summary>
        /// <param name="Photo">идентификатор фото</param>
        public void Delete(Guid Photo)
        {
            PhotoId.Remove(Photo);
        }
        /// <summary>
        /// Метод , возвращающий идентификаторы вложенных фото
        /// </summary>
        /// <param name="List">Список фотографий</param>
        /// <returns></returns>
        public Guid[] Look(List<Guid> List)
        {
            Guid[] numbers = List.ToArray<Guid>();
            return numbers;
        }
    }
}
