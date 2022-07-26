using CrudCarsTokens.Entities;
using CrudCarsTokens.Repositories.Interfaces;
using CrudCarsTokens.Services.Interfaces;

namespace CrudCarsTokens.Services
{
    public class CarrosService : ICarrosService
    {
        private readonly IDapperContext _dapperContext;

        public CarrosService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Carro>> ListarCarros()
        {
            var carros = await _dapperContext.ListarCarros();

            return carros;
        }

        public async Task<Carro> ObterCarroPorId(int id)
        {
            var carro = await _dapperContext.ObterCarroPorId(id);

            return carro;
        }
    }
}
