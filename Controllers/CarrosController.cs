using CrudCarsTokens.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudCarsTokens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly ICarrosService _carrosService;

        public CarrosController(ICarrosService carrosService)
        {
            _carrosService = carrosService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterCarroPorId(int id)
        {
            var carro = await _carrosService.ObterCarroPorId(id);

            if (carro == null) return NotFound();

            return Ok(carro);
        }

        [HttpGet()]
        public async Task<IActionResult> ListarCarros()
        {
            var carro = await _carrosService.ListarCarros();

            if (carro == null) return NotFound();

            return Ok(carro);
        }

        [HttpPost()]
        public IActionResult AdicionarCarro()
        {
            return Ok("Carro adicionado");
        }

        [HttpPut()]
        public IActionResult AtualizarCarro()
        {
            return Ok("Carro atualizado");
        }

        [HttpDelete()]
        public IActionResult DeletarCarro()
        {
            return Ok("Carro Deletado");
        }
    }
}
