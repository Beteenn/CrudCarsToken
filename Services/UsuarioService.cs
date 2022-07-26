using AutoMapper;
using CrudCarsTokens.Cryptography;
using CrudCarsTokens.Dtos;
using CrudCarsTokens.Entities;
using CrudCarsTokens.Repositories.Interfaces;
using CrudCarsTokens.Services.Interfaces;

namespace CrudCarsTokens.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IDapperContext _dapperContext;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UsuarioService(IDapperContext dapperContext, IMapper mapper, ITokenService tokenService)
        {
            _dapperContext = dapperContext;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task AdicionarUsuario(UsuarioDto usuarioDto)
        {
            var novoUsuario = new Usuario(usuarioDto.Id, usuarioDto.Nome, usuarioDto.Email);

            var hash = _tokenService.GerarHashSenha(usuarioDto.HashSenha);

            novoUsuario.AdicionarHashSenha(hash);

            await _dapperContext.AdicionarUsuario(novoUsuario);
        }

        public async Task<bool> Login(string nomeUsuario, string senha)
        {
            var usuario = await _dapperContext.ObterUsuarioPorNome(nomeUsuario);

            if (usuario == null) return false;

            var senhaValida = ValidarSenha(senha, usuario.HashSenha);

            return senhaValida;
        }

        private bool ValidarSenha(string senha, string hash)
        {
            var senhaDecripto = _tokenService.DecriptarHashSenha(hash);

            return senha == senhaDecripto;
        }
    }
}
