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


        [HttpGet()]
        public IActionResult ListarCarros()
        {
            return Ok("Listando Carros");
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
