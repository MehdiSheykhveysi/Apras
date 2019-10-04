using App01.Domain.Entities.Common;
using System;

namespace App01.Domain.Entities
{
    public class AdPicture : BaseEntity
    {
        public string ImagePath { get; set; }
        //Foregion Keys

        public Guid PosterID { get; set; }

        //navigation Property

        public Poster Poster { get; set; }
    }
}