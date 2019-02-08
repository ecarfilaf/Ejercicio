using Database;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly DbProducto dbProducto;

        public ProductoController(DbProducto dbProducto)
        {
            this.dbProducto = dbProducto;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.dbProducto.GetAll());
        }

        [HttpGet("{CodProducto}")]
        public IActionResult Get(string CodProducto)
        {
            var Producto = this.dbProducto.GetByCodProducto(CodProducto);

            if(Producto == null)
            {
				//return BadRequest($"El Producto {CodProducto} no se encuentra registrado.");
				//return NotFound(new object[1]{$"El Producto {CodProducto} no se encuentra registrado."});
				Producto = new Models.Producto
				{
					CodStatus = 1,
					DesStatus = $"El Producto {CodProducto} no se encuentra registrado."
				};
			}

            return Ok(Producto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Producto Producto)
        {
            var result = this.dbProducto.Create(Producto);

            if(result == null)
            {
                return BadRequest($"No fue posible crear al Producto {Producto.CodProducto}.");
            }
            return Ok(result);
        }

        [HttpDelete("{CodProducto}")]
        public IActionResult Delete(string CodProducto)
        {
            var result = this.dbProducto.Delete(CodProducto);
            if(result == null)
            {
                return BadRequest($"No fue posible eliminar al Producto {CodProducto}.");
            }

            return Ok(result);
        }

    }
}