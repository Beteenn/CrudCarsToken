using AutoMapper;
using CrudCarsTokens.Dtos;
using CrudCarsTokens.Entities;
using CrudCarsTokens.Repositories.Interfaces;
using CrudCarsTokens.Services.Interfaces;
using CrudCarsTokens.ViewModels;

namespace CrudCarsTokens.Services
{
    public class CarrosService : ICarrosService
    {
        private readonly IDapperContext _dapperContext;
        private readonly IMapper _mapper;

        public CarrosService(IDapperContext dapperContext, IMapper mapper)
        {
            _dapperContext = dapperContext;
            _mapper = mapper;

        }

        public async Task<IEnumerable<CarroViewModel>> ListarCarros()
        {
            var carros = await _dapperContext.ListarCarros();

            return _mapper.Map<IEnumerable<CarroViewModel>>(carros);
        }

        public async Task<CarroViewModel> ObterCarroPorId(int id)
        {
            var carro = await _dapperContext.ObterCarroPorId(id);

            return _mapper.Map<CarroViewModel>(carro);
        }

        public async Task AdicionarCarro(CarroDto carro)
        {
            var novoCarro = new Carro(carro.Nome, carro.Versao, carro.ImagemUrl);

            await _dapperContext.AdicionarCarro(novoCarro);
        }

        public async Task AtualizarCarro(CarroDto carro)
        {
            var carroAtualizado = new Carro(carro.Id, carro.Nome, carro.Versao, carro.ImagemUrl);

            await _dapperContext.AtualizarCarro(carroAtualizado);
        }

        public async Task DeleteCarro(int carroId)
        {
            await _dapperContext.DeleteCarro(carroId);
        }
    }
}
