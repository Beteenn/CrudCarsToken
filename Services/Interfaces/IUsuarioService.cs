using CrudCarsTokens.Dtos;

namespace CrudCarsTokens.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task AdicionarUsuario(UsuarioDto usuarioDto);
        Task<bool> Login(string nomeUsuario, string senha);
    }
}
