using CrudCarsTokens.Dtos;
using CrudCarsTokens.ViewModels;

namespace CrudCarsTokens.Services.Interfaces
{
    public interface IAuthService
    {
        TokenViewModel CriarTokenEscrita();
        TokenValidoViewModel ValidarTokenEscrita(string token);
        TokenViewModel CriarTokenLeitura();
        TokenValidoViewModel ValidarTokenLeitura(string token);
        LoginViewModel Login(LoginDto loginDto);
    }
}
