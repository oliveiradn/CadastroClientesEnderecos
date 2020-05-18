using Cadastro.Dominio.Entidades.Clientes;
using Cadastro.Dominio.Entidades.Enderecos;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Dominio.Contexto
{
    public class ContextoDb : DbContext
    {
        public ContextoDb(DbContextOptions<ContextoDb> options) : base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Notification>();

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Server=QSBR-NB5\SQLEXPRESS;Database=TesteApi;Trusted_Connection=True;");
    }
}