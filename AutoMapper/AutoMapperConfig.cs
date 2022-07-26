using AutoMapper;

namespace CrudCarsTokens.AutoMapper
{
    public class AutoMapperConfig
    {
        private IMapper _mapper;

        public AutoMapperConfig()
        {
            var config = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EntityToViewModelProfile());
            });

            _mapper = config.CreateMapper();
        }

        public IMapper Mapper => _mapper;
    }
}
