using CrudCarsTokens.Dtos;
using CrudCarsTokens.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudCarsTokens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var resultado = _authService.Login(loginDto);

            if (resultado == null) return BadRequest("Erro ao gerar token.");

            return Ok(resultado);
        }

        [HttpGet("TokenEscrita")]
        public IActionResult ValidarTokenEscrita(string token)
        {
            var resultado = _authService.ValidarTokenEscrita(token);

            return Ok(resultado);
        }

        [HttpPost("TokenEscrita")]
        public IActionResult GerarTokenEscrita()
        {
            var resultado = _authService.CriarTokenEscrita();

            if (resultado == null) return BadRequest("Erro ao gerar token.");

            return Ok(resultado);
        }

        [HttpGet("TokenLeitura")]
        public IActionResult ValidarTokenLeitura(string token)
        {
            var resultado = _authService.ValidarTokenLeitura(token);

            return Ok(resultado);
        }

        [HttpPost("TokenLeitura")]
        public IActionResult GerarTokenLeitura()
        {
            var resultado = _authService.CriarTokenLeitura();

            if (resultado == null) return BadRequest("Erro ao gerar token.");

            return Ok(resultado);
        }
    }
}
