using App05.Bootstraper.Extensions;
using AutoMapper;

namespace App05.Bootstraper.Mapping
{

    public class AutoMapperConfiguration
    {
        public IMapper Mapper { get; set; }
        private readonly MapperConfiguration _mapperConfiguration;

        public AutoMapperConfiguration()
        {
            _mapperConfiguration = new MapperConfiguration(c =>
            {
                c.GetConfiguration(this.GetType().Assembly);
            });

            Mapper = _mapperConfiguration.CreateMapper();
            _mapperConfiguration.CompileMappings();
        }
    }
}
