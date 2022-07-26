using CrudCarsTokens.Dtos;
using CrudCarsTokens.ViewModels;

namespace CrudCarsTokens.Services.Interfaces
{
    public interface ICarrosService
    {
        Task<IEnumerable<CarroViewModel>> ListarCarros();
        Task<CarroViewModel> ObterCarroPorId(int id);
        Task AdicionarCarro(CarroDto carro);
        Task AtualizarCarro(CarroDto carro);
        Task DeleteCarro(int carroId);
    }
}
