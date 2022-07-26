using CrudCarsTokens.Entities;
using CrudCarsTokens.Repositories.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace CrudCarsTokens.Repositories
{
    public class DapperContext : DbContext, IDapperContext, IDisposable
    {
        public IDbConnection DbConnection { get; private set; }


        public DapperContext(IConfiguration configuration)
        {
            DbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public void Dispose()
        {
            DbConnection.Dispose();
        }

        public async Task<IEnumerable<Carro>> ListarCarros()
        {
            var sql = $"Select * from Carro";
            var carro = await DbConnection.QueryAsync<Carro>(sql);

            return carro;
        }

        public async Task<Carro> ObterCarroPorId(int carroId)
        {
            var sql = $"Select * from Carro WHERE Id = {carroId}";
            var carro = await DbConnection.QueryAsync<Carro>(sql);

            return carro.FirstOrDefault();
        }

        public async Task AdicionarCarro(Carro novoCarro)
        {
            var sql = $"INSERT INTO Carro (Nome, Versao, ImagemUrl) VALUES ('{novoCarro.Nome}', '{novoCarro.Versao}', '{novoCarro.ImagemUrl}')";

            await DbConnection.ExecuteAsync(sql);
        }

        public async Task AtualizarCarro(Carro carroAtualizado)
        {
            var sql = $"UPDATE Carro SET Nome = '{carroAtualizado.Nome}', Versao = '{carroAtualizado.Versao}', ImagemUrl = '{carroAtualizado.ImagemUrl}' WHERE Id = {carroAtualizado.Id}";

            await DbConnection.ExecuteAsync(sql);
        }

        public async Task DeleteCarro(int id)
        {
            var sql = $"DELETE Carro WHERE Id = {id}";

            await DbConnection.ExecuteAsync(sql);
        }
    }
}
