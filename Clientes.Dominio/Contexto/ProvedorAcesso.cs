using Cadastro.Infraestrutura.Conexoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cadastro.Dominio.Contexto
{
    public class ProvedorAcesso
    {
        public IConfiguration Configuration;

        public static ContextoDeDados Conexao()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextoDeDados>().UseSqlServer(ConexaoAcesso.ConexaoBancoSql);

            return new ContextoDeDados(optionsBuilder.Options);
        }
    }
}