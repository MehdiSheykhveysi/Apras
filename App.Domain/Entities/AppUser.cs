using App01.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace App01.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>, IEntity
    {


        //Navigation Property

        public ICollection<Poster> Posters { get; set; }
    }
}