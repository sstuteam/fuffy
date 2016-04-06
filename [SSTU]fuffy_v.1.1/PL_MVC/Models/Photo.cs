﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  

namespace PL_MVC.Models
{
    public class Photo
    {
        public string Name { get; set; }
        public Guid IDPhoto;
        public Guid IDAlbum;
        public int CountLikes { get; set; }
        public string Spetification { get; set; }
        public byte[] Image { get; set; }
        public Photo() { }
        public string ImageType { get; set; }

        public static implicit operator Entities.Photo(Photo photoModel)
        {
            if (photoModel != null)
            {
                Entities.Photo photoEntities = new Entities.Photo()
                {
                    IDPhoto=photoModel.IDPhoto,
                    IDAlbum=photoModel.IDAlbum,
                    CountLikes=photoModel.CountLikes,
                    Name=photoModel.Name,
                    Spetification=photoModel.Spetification,
                    Image=photoModel.Image                    
                };
                return photoEntities;                
            }
            return null;
        }

        public static implicit operator Photo(Entities.Photo photoEntities)
        {
            if (photoEntities != null)
            {
                Photo photoModel = new Photo()
                {
                    CountLikes=photoEntities.CountLikes,
                    IDAlbum=photoEntities.IDAlbum,
                    IDPhoto=photoEntities.IDPhoto,
                    Image=photoEntities.Image,
                    Name=photoEntities.Name,
                    Spetification=photoEntities.Spetification
                };                
                return photoModel;
            }
            return null;
        }
        //public IEnumerable<Entities.Photo> GetAllPhoto()
        //{
        //    return Binder.GetAllPhoto(IDAlbum);
        //}
    }
}
