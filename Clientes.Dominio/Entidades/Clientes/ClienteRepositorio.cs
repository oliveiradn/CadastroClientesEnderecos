using Cadastro.Dominio.Abstracoes;
using Cadastro.Dominio.Contexto;
using System.Linq;

namespace Cadastro.Dominio.Entidades.Clientes
{
    public class ClienteRepositorio : Repositorio<Cliente>
    {
        public virtual bool ExistePeloCpf(string cpf)
        {
            using (var context = ProvedorAcesso.Conexao())
            {
                var dbSet = context.Set<Cliente>();

                return dbSet.Where(x => x.Cpf == cpf).Any();
            }
        }

        public virtual bool ExistePeloCpfEIdDiferente(long id, string cpf)
        {
            using (var context = ProvedorAcesso.Conexao())
            {
                var dbSet = context.Set<Cliente>();

                return dbSet.Where(x => x.Id != id && x.Cpf == cpf).Any();
            }
        }
    }
}