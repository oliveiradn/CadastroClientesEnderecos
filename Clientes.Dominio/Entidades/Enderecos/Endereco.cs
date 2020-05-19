using Cadastro.Dominio.Abstracoes;
using Flunt.Validations;
using System.ComponentModel.DataAnnotations;

namespace Cadastro.Dominio.Entidades.Enderecos
{
    public class Endereco : Entidade
    {
        [Required]
        [MaxLength(50)]
        public string Logradouro { get; private set; }

        [Required]
        [MaxLength(40)]
        public string Bairro { get; private set; }

        [Required]
        [MaxLength(40)]
        public string Cidade { get; private set; }

        [Required]
        [MaxLength(40)]
        public string Estado { get; private set; }

        public void CopiarDoModelo(EnderecoModelo EnderecoModelo)
        {
            if (EnderecoModelo == null) AddNotification("EnderecoModelo", "A Classe 'EnderecoModelo' não foi instânciada");

            if (Valid)
            {
                if (EnderecoModelo.Logradouro != null)
                    Logradouro = EnderecoModelo.Logradouro.Trim();

                if (EnderecoModelo.Bairro != null)
                    Bairro = EnderecoModelo.Bairro.Trim();

                if (EnderecoModelo.Cidade != null)
                    Cidade = EnderecoModelo.Cidade.Trim();

                if (EnderecoModelo.Estado != null)
                    Estado = EnderecoModelo.Estado.Trim();

                Validar();
            }
        }

        protected override Contract ConfigurarContrato(Contract contract) => contract;
    }
}