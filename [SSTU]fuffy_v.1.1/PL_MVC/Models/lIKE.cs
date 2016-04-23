using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL_MVC.Models
{
    public class Like
    {
        public Guid PhotoId { get; set; }
        public Guid UserId { get; set; }
        public static implicit operator Entities.Like(Like LikeModel)
        {
            if (LikeModel != null)
            {
                Entities.Like LikeEntities = new Entities.Like()
                {
                    PhotoId = LikeModel.PhotoId,
                    UserId = LikeModel.UserId
                };
                return LikeEntities;
            }
            return null;
        }

        public static implicit operator Like(Entities.Like LikeEntities)
        {
            if (LikeEntities != null)
            {
                Like photoModel = new Like()
                {
                    PhotoId = LikeEntities.PhotoId,
                    UserId = LikeEntities.UserId
                };
                return photoModel;
            }
            return null;
        }
    }
}