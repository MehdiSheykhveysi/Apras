using App01.Domain.Entities.Common;
using System.Collections.Generic;

namespace App01.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }

        //Foreign Keys
        
        public int? ParentCategoryID { get; set; }

        //NavigationProperty

        public Category ParentCategory { get; set; }

        public ICollection<Poster> Posters { get; set; }
        public ICollection<Category> ChildCategories { get; set; }
    }
}