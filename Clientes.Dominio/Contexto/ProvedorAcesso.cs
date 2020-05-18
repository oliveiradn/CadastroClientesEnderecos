using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cadastro.Dominio.Contexto
{
    public class ProvedorAcesso
    {
        public IConfiguration Configuration;

        public ContextoDb Conexao()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextoDb>().UseSqlServer(@"Server=QSBR-NB5\\SQLEXPRESS;Database=TesteApi;Trusted_Connection=True;");

            return new ContextoDb(optionsBuilder.Options);
        }

        ////private string StringDeConexao() => Configuration.GetConnectionString("DefaultConnection");
        ////private string StringDeConexao() => @"Server=QSBR-NB5\\SQLEXPRESS;Database=TesteApi;Trusted_Connection=True;";//Configuration.GetConnectionString("DefaultConnection");
    }
}