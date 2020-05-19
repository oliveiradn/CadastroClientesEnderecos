using Cadastro.Dominio.Abstracoes;
using Cadastro.Infraestrutura.Extensoes;
using Flunt.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cadastro.Dominio.Entidades.Clientes
{
    public class Cliente : Entidade
    {
        [Required]
        [MaxLength(30)]
        public string Nome { get; private set; }

        [Required]
        [MaxLength(14)]
        public string Cpf { get; private set; }

        [Required]
        public DateTime DataNascimento { get; private set; }

        public void CopiarDoModelo(ClienteModelo clienteModelo)
        {
            if (clienteModelo == null) AddNotification("ClienteModelo", "A Classe 'ClienteModelo' não foi instânciada");

            if (Valid)
            {
                if (clienteModelo.Nome != null)
                    Nome = clienteModelo.Nome.Trim();
                if (clienteModelo.Cpf != null)
                    Cpf = clienteModelo.Cpf.Trim().RemoverCaracterEspecial();
                if (clienteModelo.DataNascimento != DateTime.MinValue)
                    DataNascimento = clienteModelo.DataNascimento;
                Validar();
            }
        }

        protected override Contract ConfigurarContrato(Contract contract)
        {
            if (!ValidarCPF(Cpf))
                contract.AddNotification("Cpf", $"O Cpf '{Cpf}' do Cliente é inválido.");

            return contract;
        }
    }
}