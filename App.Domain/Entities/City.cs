using App01.Domain.Entities.Common;

namespace App01.Domain.Entities
{
    public class City: BaseEntity
    {
        public string Name { get; set; }

        //Foreign Keys

        public int ProvinceId { get; set; }

        //Navigation Property

        public Province Province { get; set; }
    }
}