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
            var EnderecoModelo = new EnderecoModelo();
            var Enderecos = new EnderecoRepositorio().BuscarTudo();

            if (Enderecos.Any())
            {
                foreach (var item in Enderecos)
                    EnderecoModelo.CopiarDaEntidade(item);

                return Ok(EnderecoModelo.ParaJson());
            }
            else
                return NotFound("Registros não foram encontrados");
        }

        // GET: api/Enderecos/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
            var EnderecoModelo = new EnderecoModelo();
            var retorno = new EnderecoRepositorio().BuscarPeloId(id);

            if (retorno.Id > 0)
            {
                EnderecoModelo.CopiarDaEntidade(retorno);
                return Ok(EnderecoModelo.ParaJson());
            }
            else
                return NotFound("Endereco não encontrado");
        }

        // POST: api/Enderecos
        [HttpPost]
        public IActionResult Post([FromBody] EnderecoModelo modelo)
        {
            var entidade = new Endereco();

            entidade.CopiarDoModelo(modelo);

            if (entidade.Valid)
            {
                new EnderecoRepositorio().Inserir(entidade);
                return Ok("Endereco inserido com sucesso");
            }
            else
                return BadRequest(error: entidade.Notifications);
        }

        // PUT: api/Enderecos/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]long id, [FromBody] EnderecoModelo modelo)
        {
            var entidade = new Endereco();

            entidade.CopiarDoModelo(modelo);

            if (entidade.Valid)
                if (new EnderecoRepositorio().ExistePeloId(id))
                {
                    new EnderecoRepositorio().Atualizar(entidade);
                    return Ok("Endereco atualizado com sucesso");
                }
                else
                    return NotFound("Endereco não encontrado");

            return BadRequest(entidade.Notifications);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]long id)
        {
            var entidade = new EnderecoRepositorio().BuscarPeloId(id);

            if (entidade.Id > 0)
            {
                new EnderecoRepositorio().Deletar(entidade);
                return Ok("Deletado com sucesso");
            }
            else
                return BadRequest("Registro não encontrado");
        }
    }
}