using Cadastro.Dominio.Abstracoes;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Cadastro.Dominio.Entidades.Clientes
{
    public class ClienteModelo : Modelo<Cliente>
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "O campo nome permite no máximo 30 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(14, ErrorMessage = "O Cpf permite no máximo 14 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataNascimento { get; set; }

        public override void CopiarDaEntidade(Cliente entidade)
        {
            Nome = entidade.Nome;
            Cpf = entidade.Cpf;
            DataNascimento = entidade.DataNascimento;
        }

        public static string ParaJson(this ClienteModelo clienteModelo) => JsonConvert.SerializeObject(clienteModelo);
    }
}