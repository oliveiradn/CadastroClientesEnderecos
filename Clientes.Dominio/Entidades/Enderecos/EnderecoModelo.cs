using Cadastro.Dominio.Abstracoes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Cadastro.Dominio.Entidades.Enderecos
{
    public class EnderecoModelo : Modelo<Endereco>
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "O campo nome permite no máximo 50 caracteres")]
        public string Logradouro { get; set; } //50

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "O campo nome permite no máximo 40 caracteres")]
        public string Bairro { get; set; } //40

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "O campo nome permite no máximo 40 caracteres")]
        public string Cidade { get; set; } //40

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "O campo nome permite no máximo 40 caracteres")]
        public string Estado { get; set; } //40

        public override void CopiarDaEntidade(Endereco entidade)
        {
            Logradouro = entidade.Logradouro;
            Bairro = entidade.Bairro;
            Cidade = entidade.Cidade;
            Estado = entidade.Estado;
        }
    }
}