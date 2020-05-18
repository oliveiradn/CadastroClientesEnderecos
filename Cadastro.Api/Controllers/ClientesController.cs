using Cadastro.Dominio.Entidades.Clientes;
using Cadastro.Infraestrutura.Extensao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

namespace Cadastro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        // GET: api/Clientes
        [HttpGet]
        public IActionResult Get()
        {
            var clienteModelo = new ClienteModelo();
            var clientes = new ClienteRepositorio().GetAll();

            if (clientes.Any())
            {
                foreach (var item in clientes)
                    clienteModelo.CopiarDaEntidade(item);

                return Ok(clienteModelo.ParaJson());
            }
            else
                return NotFound("Registros não foram encontrados");
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
            var clienteModelo = new ClienteModelo();
            var retorno = new ClienteRepositorio().GetById(id);

            if (retorno.Id > 0)
            {
                clienteModelo.CopiarDaEntidade(retorno);
                return Ok(clienteModelo.ParaJson());
            }
            else
                return NotFound("Cliente não encontrado");
        }

        // POST: api/Clientes
        [HttpPost]
        public IActionResult Post([FromBody] ClienteModelo modelo)
        {
            var entidade = new Cliente();

            entidade.CopiarDoModelo(modelo);

            if (entidade.Valid)
            {
                if (!new ClienteRepositorio().ExistisByCpf(entidade.Cpf))
                {
                    new ClienteRepositorio().Insert(entidade);
                    return Ok("Cliente inserido com sucesso");
                }
                else
                    return BadRequest($"O Cliente com Cpf {entidade.Cpf} já consta no sistema.");
            }
            else
                return BadRequest(error: entidade.Notifications);
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]long id, [FromBody] ClienteModelo modelo)
        {
            var entidade = new Cliente();

            entidade.CopiarDoModelo(modelo);

            if (entidade.Valid)
                if (new ClienteRepositorio().ExistisById(id))
                {
                    new ClienteRepositorio().Update(entidade);
                    return Ok("Cliente atualizado com sucesso");
                }
                else
                    return NotFound("Cliente não encontrado");

            return BadRequest(entidade.Notifications);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]long id)
        {
            var entidade = new ClienteRepositorio().GetById(id);

            if (entidade.Id > 0)
            {
                new ClienteRepositorio().Delete(entidade);
                return Ok("Deletado com sucesso");
            }
            else
                return BadRequest("Registro não encontrado");
        }
    }
}