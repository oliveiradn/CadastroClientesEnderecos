using Cadastro.Dominio.Entidades.Enderecos;
using Cadastro.Infraestrutura.Extensoes;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Cadastro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        // GET: api/Enderecos
        [HttpGet]
        public IActionResult Get()
        {
            var enderecos = new EnderecoRepositorio().BuscarTudo();

            if (!enderecos.Any())
                return NotFound("Registros não foram encontrados");

            var enderecosModelo = EnderecoServico.CriarListaEnderecosModelo(enderecos);
            return Ok(enderecosModelo.ParaJson());
        }

        // GET: api/Enderecos/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
            var endereco = new EnderecoRepositorio().BuscarPeloId(id);

            if (endereco == null)
                return NotFound("Endereco não encontrado");

            var enderecoModelo = new EnderecoModelo();
            enderecoModelo.CopiarDaEntidade(endereco);
            return Ok(enderecoModelo.ParaJson());
        }

        // POST: api/Enderecos
        [HttpPost]
        public IActionResult Post([FromBody] EnderecoModelo modelo)
        {
            var endereco = new Endereco();
            endereco.CopiarDoModelo(modelo);

            if (endereco.Invalid)
                return BadRequest(error: endereco.Notifications);

            new EnderecoRepositorio().Inserir(endereco);
            return Ok("Endereco inserido com sucesso");
        }

        // PUT: api/Enderecos/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]long id, [FromBody] EnderecoModelo modelo)
        {
            var endereco = new EnderecoRepositorio().BuscarPeloId(id);
            if (endereco == null)

                return NotFound("Endereco não encontrado");

            endereco.CopiarDoModelo(modelo);

            if (endereco.Invalid)
                return BadRequest(endereco.Notifications);

            new EnderecoRepositorio().Atualizar(endereco);
            return Ok("Endereco atualizado com sucesso");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]long id)
        {
            var endereco = new EnderecoRepositorio().BuscarPeloId(id);

            if (endereco == null)
                return BadRequest("Registro não encontrado");

            new EnderecoRepositorio().Deletar(endereco);
            return Ok("Deletado com sucesso");
        }
    }
}