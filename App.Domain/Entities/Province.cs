using App01.Domain.Entities.Common;
using System.Collections.Generic;

namespace App01.Domain.Entities
{
    public class Province : BaseEntity
    {
        public string Name { get; set; }

        //Navigation Property

        public ICollection<City> Cities { get; set; }
        public ICollection<Poster> Posters { get; set; }
    }
}