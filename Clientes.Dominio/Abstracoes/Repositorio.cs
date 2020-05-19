using Cadastro.Dominio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro.Dominio.Abstracoes
{
    public class Repositorio<T> where T : Entidade
    {
        public virtual T BuscarPeloId(long id)
        {
            using (var context = new ProvedorAcesso().Conexao())
            {
                var dbSet = context.Set<T>();

                var dado = dbSet.Where(x => x.Id == id).FirstOrDefault();

                return dado;
            }
        }

        public virtual bool ExistePeloId(long id)
        {
            using (var context = new ProvedorAcesso().Conexao())
            {
                var dbSet = context.Set<T>();

                return dbSet.Where(x => x.Id == id).Any();
            }
        }

        public virtual IEnumerable<T> BuscarTudo()
        {
            using (var context = new ProvedorAcesso().Conexao())
            {
                var dbSet = context.Set<T>();

                var dado = dbSet.ToList();

                return dado;
            }
        }

        public virtual void Inserir(T entity)
        {
            using (var context = new ProvedorAcesso().Conexao())
            {
                var dbSet = context.Set<T>();

                dbSet.Add(entity);

                context.SaveChanges();
            }
        }

        public virtual void Atualizar(T entity)
        {
            using (var context = new ProvedorAcesso().Conexao())
            {
                var dbSet = context.Set<T>();

                dbSet.Update(entity);

                context.SaveChanges();
            }
        }

        public virtual void Deletar(T entity)
        {
            using (var context = new ProvedorAcesso().Conexao())
            {
                var dbSet = context.Set<T>();

                var now = DateTime.Now;

                dbSet.Remove(entity);

                context.SaveChanges();
            }
        }
    }
}