using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET.Model;
using RestWithASPNET.Services;


namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {

        private readonly ILogger<VeiculoController> _logger;
        private IVeiculoService _veiculoService;

        public VeiculoController(ILogger<VeiculoController> logger, IVeiculoService veiculoService)
        {
            _logger = logger;
            _veiculoService = veiculoService;
        }


        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_veiculoService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _veiculoService.FindByID(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost()]
        public IActionResult CreateVeiculo([FromBody] Veiculo veiculo)
        {
            if (veiculo == null)
            {
                return BadRequest();
            }

            return Ok(_veiculoService.Create(veiculo));
        }


        [HttpPut()]
        public IActionResult UpdateVeiculo([FromBody] Veiculo veiculo)
        {
            if (veiculo == null)
            {
                return BadRequest();
            }

            return Ok(_veiculoService.Update(veiculo));
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteVeiculo(long id)
        {
            _veiculoService.Delete(id);

            return NoContent();
        }




        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}
