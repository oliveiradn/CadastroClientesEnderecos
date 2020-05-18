using Cadastro.Dominio.Abstracoes;
using Cadastro.Dominio.Contexto;
using DocumentosBrasileiros;
using System.Linq;

namespace Cadastro.Dominio.Entidades.Clientes
{
    public class ClienteRepositorio : Repositorio<Cliente>
    {
        public virtual bool ExistisByCpf(string cpf)
        {
            using (var context = new ProvedorAcesso().Conexao())
            {
                var dbSet = context.Set<Cliente>();

                return dbSet.Where(x => x.Cpf == cpf).Any();
            }
        }
    }
}