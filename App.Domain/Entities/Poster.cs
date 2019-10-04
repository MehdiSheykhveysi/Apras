using App01.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace App01.Domain.Entities
{
    public class Poster : BaseEntity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string WebSiteAddress { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }

        //Foreign Keys

        public int ProvinceId { get; set; }
        public int CategoryID { get; set; }
        public Guid AppUserId { get; set; }

        //NaviGationProperty
        public ICollection<AdPicture> AdPictures { get; set; }
        public ICollection<Keyword> KeyWords { get; set; }
        public Category Category { get; set; }
        public Province Province { get; set; }
        public AppUser AppUser { get; set; }
    }
}