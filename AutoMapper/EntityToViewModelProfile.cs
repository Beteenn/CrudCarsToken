using AutoMapper;
using CrudCarsTokens.Entities;
using CrudCarsTokens.ViewModels;

namespace CrudCarsTokens.AutoMapper
{
    public class EntityToViewModelProfile : Profile
    {

        public EntityToViewModelProfile()
        {
            CreateMap<Carro, CarroViewModel>()
                .ReverseMap();
        }
    }
}
