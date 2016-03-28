using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_MVC.Models
{
    public class Album
    {
        public string Name { get; set; }
        public string Spetification { get; set; }
        public Guid IDAlbum;
        public Guid IDUser;

        public Album() { IDAlbum = Guid.NewGuid(); Spetification = "Defoult"; }

        public static implicit operator Entities.Album(Album albumModel)
        {
            if (albumModel != null)
            {
                Entities.Album albumEntities = new Entities.Album()
                {
                    IDAlbum = albumModel.IDAlbum,
                    IDUser = albumModel.IDUser,
                    Name = albumModel.Name,
                    Spetification = albumModel.Spetification
                };
                return albumEntities;
            }
            return null;
        }

        public static implicit operator Album(Entities.Album albumEntities)
        {
            if (albumEntities != null)
            {
                Album albumModel = new Album()
                {
                    IDAlbum = albumEntities.IDAlbum,
                    IDUser = albumEntities.IDUser,
                    Name = albumEntities.Name,
                    Spetification = albumEntities.Spetification
                };
                return albumModel;
            }
            return null;
        }
    }
}
