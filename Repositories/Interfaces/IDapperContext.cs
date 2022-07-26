using CrudCarsTokens.Entities;

namespace CrudCarsTokens.Repositories.Interfaces
{
    public interface IDapperContext
    {
        Task<IEnumerable<Carro>> ListarCarros();
        Task<Carro> ObterCarroPorId(int carroId);
        Task AdicionarCarro(Carro novoCarro);
        Task AtualizarCarro(Carro carroAtualizado);
        Task DeleteCarro(int id);
    }
}
