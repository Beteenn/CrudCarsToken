using CrudCarsTokens.Entities;

namespace CrudCarsTokens.Services.Interfaces
{
    public interface ICarrosService
    {
        Task<IEnumerable<Carro>> ListarCarros();
        Task<Carro> ObterCarroPorId(int id);
    }
}
