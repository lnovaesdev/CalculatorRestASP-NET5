using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET.Model;
using RestWithASPNET.Services;


namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguroController : ControllerBase
    {

        private readonly ILogger<SeguroController> _logger;
        private ISeguroService _seguroService;
        private IPersonService _personService;
        private IVeiculoService _veiculoService;

        public SeguroController(ILogger<SeguroController> logger, ISeguroService seguroService, IPersonService   personService, IVeiculoService veiculoService)
        {
            _logger = logger;
            _seguroService = seguroService;
            _personService = personService;
            _veiculoService = veiculoService;
        }

        //calcula média de seguros cadastrados
        [HttpGet]
        public IActionResult Get()
        {
            var seguros = _seguroService.FindAll();
            decimal soma = 0;
            foreach(var item in seguros)
            {
                soma = soma + item.ValorSeguro;
            }

            var media = soma / seguros.Count;

            return Ok(media.ToString());
        }


        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var seguro = _seguroService.FindByID(id);
            if (seguro == null)
            {
                return NotFound();
            }

            return Ok(seguro);
        }

        //Cria e calcula seguro
        [HttpPost("calcula/{idsegurado}/{idveiculo}")]
        public IActionResult CreateSeguro(long idSegurado, long idVeiculo)
        {
            Seguro seguro = new Seguro();

            var segurado = _personService.FindByID(idSegurado);
            var veiculo = _veiculoService.FindByID(idVeiculo);
            decimal margem_seguranca = 3;
            decimal lucro = 5;

            if (segurado == null || veiculo == null)
            {

                return BadRequest();

            }
            else
            {
                decimal taxa_risco = (veiculo.Valor * 5) / (2 * veiculo.Valor);
                decimal premio_risco = (taxa_risco / 100) * veiculo.Valor;
                decimal premio_puro = premio_risco * (1 + (margem_seguranca / 100));
                decimal premio_comercial = (lucro / 100) * premio_puro;

                seguro.IdPerson = idSegurado;
                seguro.IdVeiculo = idVeiculo;
                seguro.ValorSeguro = premio_comercial;
            }


            return Ok(_seguroService.Create(seguro));
        }


        [HttpPut()]
        public IActionResult UpdateSeguro([FromBody] Seguro seguro)
        {
            if (seguro == null)
            {
                return BadRequest();
            }

            return Ok(_seguroService.Update(seguro));
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteSeguro(long id)
        {
            _seguroService.Delete(id);

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
