using CrudCarsTokens.Cryptography;
using CrudCarsTokens.Dtos;
using CrudCarsTokens.Services.Interfaces;
using CrudCarsTokens.ViewModels;

namespace CrudCarsTokens.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;

        public AuthService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public TokenViewModel CriarTokenEscrita()
        {
            var token = _tokenService.GerarTokenEscrita();

            return new TokenViewModel { Token = token };
        }

        public TokenValidoViewModel ValidarTokenEscrita(string token)
        {
            var tokenValido = _tokenService.ValidarTokenEscrita(token);

            return new TokenValidoViewModel { Valido = tokenValido };
        }

        public TokenViewModel CriarTokenLeitura()
        {
            var token = _tokenService.GerarTokenLeitura();

            return new TokenViewModel { Token = token };
        }

        public TokenValidoViewModel ValidarTokenLeitura(string token)
        {
            var tokenValido = _tokenService.ValidarTokenLeitura(token);

            return new TokenValidoViewModel { Valido = tokenValido };
        }

        public LoginViewModel Login(LoginDto loginDto)
        {
            var tokenLeitura = _tokenService.GerarTokenLeitura();

            var tokenEscrita = _tokenService.GerarTokenEscrita();

            return new LoginViewModel { TokenEscrita = tokenEscrita, TokenLeitura = tokenLeitura };
        }
    }
}
