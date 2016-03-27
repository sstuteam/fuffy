using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Album
    {
        public string Name { get; set; }
        public string Spetification{ get; set;}
        public Guid IDAlbum;
        public Guid IDUser;
        /// <summary>
        /// Конструктор нового альбома
        /// </summary>
        /// <param name="name">Имя альбома</param>
        public Album(string name)
        {
            Name = name;
            IDAlbum = Guid.NewGuid();
        }
        
        public Album() { IDAlbum = Guid.NewGuid(); Spetification = "Defoult"; }          
    }
}
