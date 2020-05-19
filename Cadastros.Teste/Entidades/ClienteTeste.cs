using Bogus;
using Cadastro.Dominio.Entidades.Clientes;
using DocumentosBrasileiros;
using System;
using System.Linq;
using Xunit;

namespace Cadastro.Teste.Entidades
{
    public class ClienteTeste
    {
        public ClienteModelo ClienteModelo { get; private set; }
        public Cliente Cliente { get; private set; }

        public ClienteTeste()
        {
            var faker = new Faker();
            var cpf = new Cpf();

            Cliente = new Cliente();

            ClienteModelo = new ClienteModelo()
            {
                Nome = faker.Name.FullName(),
                Cpf = cpf.GerarFake(),
                DataNascimento = faker.Date.Past()
            };
        }

        [Fact]
        public void InstanciarUmClientePeloModelo()
        {
            Cliente.CopiarDoModelo(ClienteModelo);
            Assert.True(Cliente.Valid);
        }

        [Fact]
        public void InstanciarUmClientePeloModeloVazio()
        {
            var clienteModelo = new ClienteModelo();

            Cliente.CopiarDoModelo(clienteModelo);
            Assert.True(Cliente.Invalid);
        }

        [Theory]
        [InlineData(null)]
        public void InstanciarUmClientePeloModeloNulo(ClienteModelo ClienteModeloNulo)
        {
            Cliente.CopiarDoModelo(ClienteModeloNulo);
            Assert.True(Cliente.Invalid);
        }

        [Theory]
        [InlineData("123.456.78-90")]
        [InlineData("123.4b6.78-90")]
        [InlineData("1w3.4b6.t8-9q")]
        [InlineData("1234567890")]
        [InlineData("1234a67890")]
        [InlineData("12c45f78u0")]
        [InlineData("123456789")]
        [InlineData("numero do Cpf")]
        [InlineData("123")]
        [InlineData(null)]
        [InlineData("")]
        public void NaoPodeTerUmCpfInvalido(string cpf)
        {
            ClienteModelo.Cpf = cpf;

            Cliente.CopiarDoModelo(ClienteModelo);
            if (Cliente.Invalid)
                Assert.True(Cliente.Notifications.Where(x => x.Property == "Cpf").Any());
        }

        [Theory]
        [InlineData(null)]
        public void NaoPodeTerUmaDataNascimentoInvalida(DateTime dataNascimento)
        {
            ClienteModelo.DataNascimento = dataNascimento;

            Cliente.CopiarDoModelo(ClienteModelo);
            if (Cliente.Invalid)
                Assert.True(Cliente.Notifications.Where(x => x.Property == "DataNascimento").Any());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Nome de cliente absurdamente grande ultrapassando o tamanho máximo permitido")]
        public void NaoPodeTerUmNomeInvalida(string nome)
        {
            ClienteModelo.Nome = nome;

            Cliente.CopiarDoModelo(ClienteModelo);
            if (Cliente.Invalid)
                Assert.True(Cliente.Notifications.Where(x => x.Property == "Nome").Any());
        }
    }
}