using Database;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DbCliente dbCliente;

        public ClienteController(DbCliente dbCliente)
        {
            this.dbCliente = dbCliente;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.dbCliente.GetAll());
        }

        [HttpGet("{rut}")]
        public IActionResult Get(string rut)
        {
            var cliente = this.dbCliente.GetByRut(rut);

            if(cliente == null)
            {
                return BadRequest($"El cliente {rut} no se encuentra registrado.");
            }

            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            var result = this.dbCliente.Create(cliente);

            if(result == null)
            {
                return BadRequest($"No fue posible crear al cliente {cliente.Rut}.");
            }
            return Ok(result);
        }

        [HttpDelete("{rut}")]
        public IActionResult Delete(string rut)
        {
            var result = this.dbCliente.Delete(rut);
            if(result == null)
            {
                return BadRequest($"No fue posible eliminar al cliente {rut}.");
            }

            return Ok(result);
        }

    }
}