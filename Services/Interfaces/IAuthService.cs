using CrudCarsTokens.Dtos;
using CrudCarsTokens.ViewModels;

namespace CrudCarsTokens.Services.Interfaces
{
    public interface IAuthService
    {
        TokenViewModel CriarTokenEscrita();
        TokenViewModel CriarTokenLeitura();
        Task<LoginViewModel> Login(LoginDto loginDto);
    }
}
