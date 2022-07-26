using CrudCarsTokens.Dtos;
using CrudCarsTokens.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudCarsTokens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost()]
        public async Task<IActionResult> AdicionarCarro(UsuarioDto usuarioDto)
        {
            await _usuarioService.AdicionarUsuario(usuarioDto);

            return Ok("Usuario adicionado");
        }
    }
}
