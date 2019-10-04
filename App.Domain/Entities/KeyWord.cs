using App01.Domain.Entities.Common;
using System;

namespace App01.Domain.Entities
{
    public class Keyword : BaseEntity
    {
        public string Title { get; set; }

        //Foregion Keys

        public Guid PosterID { get; set; }

        //Navigation Property

        public Poster Poster { get; set; }
    }
}