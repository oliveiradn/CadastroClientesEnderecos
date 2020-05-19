using Cadastro.Dominio.Entidades.Clientes;
using Cadastro.Dominio.Entidades.Enderecos;
using Cadastro.Infraestrutura.Conexoes;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Dominio.Contexto
{
    public class ContextoDeDados : DbContext
    {
        public ContextoDeDados(DbContextOptions<ContextoDeDados> options) : base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Notification>();

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(ConexaoAcesso.ConexaoBancoSql);
    }
}