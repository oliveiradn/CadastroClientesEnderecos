using Cadastro.Dominio.Abstracoes;
using Flunt.Validations;
using System.ComponentModel.DataAnnotations;

namespace Cadastro.Dominio.Entidades.Enderecos
{
    public class Endereco : Entidade
    {
        [Required]
        [MaxLength(50)]
        public string Logradouro { get; private set; } //50

        [Required]
        [MaxLength(40)]
        public string Bairro { get; private set; } //40

        [Required]
        [MaxLength(40)]
        public string Cidade { get; private set; } //40

        [Required]
        [MaxLength(40)]
        public string Estado { get; private set; } //40

        public void CopiarDoModelo(EnderecoModelo EnderecoModelo)
        {
            if (EnderecoModelo == null) AddNotification("EnderecoModelo", "A Classe 'EnderecoModelo' não foi instânciada");

            if (Valid)
            {
                Logradouro = EnderecoModelo.Logradouro;
                Bairro = EnderecoModelo.Bairro;
                Cidade = EnderecoModelo.Cidade;
                Estado = EnderecoModelo.Estado;

                Validar();
            }
        }

        protected override Contract ConfigurarContrato(Contract contract) => contract;
    }
}