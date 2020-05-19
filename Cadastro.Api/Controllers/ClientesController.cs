using Cadastro.Dominio.Entidades.Clientes;
using Cadastro.Infraestrutura.Extensoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

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
            var clientes = new ClienteRepositorio().BuscarTudo();

            if (clientes.Any())
                return NotFound("Registros não foram encontrados");

            var clientesModelo = ClienteServico.CriarListaClientesModelo(clientes);
            return Ok(clientesModelo.ParaJson());
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
            var clienteModelo = new ClienteModelo();
            var cliente = new ClienteRepositorio().BuscarPeloId(id);

            if (cliente == null)
                return NotFound("Cliente não encontrado");

            clienteModelo.CopiarDaEntidade(cliente);
            return Ok(clienteModelo.ParaJson());
        }

        // POST: api/Clientes
        [HttpPost]
        public IActionResult Post([FromBody] ClienteModelo modelo)
        {
            var cliente = new Cliente();
            cliente.CopiarDoModelo(modelo);

            if (cliente.Invalid)
                return BadRequest(error: cliente.Notifications);

            if (!new ClienteRepositorio().ExistePeloCpf(cliente.Cpf))
                return BadRequest($"O Cliente com Cpf {cliente.Cpf} já consta no sistema.");

            new ClienteRepositorio().Inserir(cliente);
            return Ok("Cliente inserido com sucesso");
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]long id, [FromBody] ClienteModelo modelo)
        {
            var cliente = new ClienteRepositorio().BuscarPeloId(id);

            if (cliente == null)
                return NotFound("Cliente não encontrado");

            cliente.CopiarDoModelo(modelo);

            if (cliente.Invalid)
                return BadRequest(cliente.Notifications);

            if (new ClienteRepositorio().ExistePeloCpfEIdDiferente(cliente.Id, cliente.Cpf))
                return BadRequest($"O Cliente com Cpf '{cliente.Cpf}' consta em outro registro no sistema.");

            new ClienteRepositorio().Atualizar(cliente);
            return Ok("Cliente atualizado com sucesso");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]long id)
        {
            var cliente = new ClienteRepositorio().BuscarPeloId(id);

            if (cliente == null)
                return BadRequest("Registro não encontrado");

            new ClienteRepositorio().Deletar(cliente);
            return Ok("Deletado com sucesso");
        }
    }
}