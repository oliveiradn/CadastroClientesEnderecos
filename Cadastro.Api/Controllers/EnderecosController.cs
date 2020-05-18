using Cadastro.Dominio.Entidades.Enderecos;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        // GET: api/Empresas
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("");
        }

        // GET: api/Empresas/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
            return Ok("");
        }

        // POST: api/Empresas
        [HttpPost]
        public IActionResult Post([FromBody] EnderecoModelo value)
        {
            return Ok("");
        }

        // PUT: api/Empresas/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]long id, [FromBody] EnderecoModelo value)
        {
            return Ok("");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]long id)
        {
            return Ok("");
        }
    }
}