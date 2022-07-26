using CrudCarsTokens.Dtos;
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
        public async Task<IActionResult> AdicionarCarro(CarroDto carroDto)
        {
            await _carrosService.AdicionarCarro(carroDto);

            return Ok("Carro adicionado");
        }

        [HttpPut()]
        public async Task<IActionResult> AtualizarCarro(CarroDto carroDto)
        {
            await _carrosService.AtualizarCarro(carroDto);

            return Ok("Carro atualizado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarCarro(int id)
        {
            await _carrosService.DeleteCarro(id);

            return Ok("Carro Deletado");
        }
    }
}
