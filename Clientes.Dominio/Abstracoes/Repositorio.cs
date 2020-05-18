using Cadastro.Dominio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro.Dominio.Abstracoes
{
    public class Repositorio<T> where T : Entidade
    {
        public virtual T GetById(long id)
        {
            using (var context = new ProvedorAcesso().Conexao())
            {
                var dbSet = context.Set<T>();

                var dado = dbSet.Where(x => x.Id == id).FirstOrDefault();

                return dado;
            }
        }

        public virtual bool ExistisById(long id)
        {
            using (var context = new ProvedorAcesso().Conexao())
            {
                var dbSet = context.Set<T>();

                return dbSet.Where(x => x.Id == id).Any();
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            using (var context = new ProvedorAcesso().Conexao())
            {
                var dbSet = context.Set<T>();

                var dado = dbSet.ToList();

                return dado;
            }
        }

        public virtual void Insert(T entity)
        {
            using (var context = new ProvedorAcesso().Conexao())
            {
                var dbSet = context.Set<T>();

                dbSet.Add(entity);

                context.SaveChanges();
            }
        }

        public virtual void Update(T entity)
        {
            using (var context = new ProvedorAcesso().Conexao())
            {
                var dbSet = context.Set<T>();

                dbSet.Update(entity);

                context.SaveChanges();
            }
        }

        public virtual void Delete(T entity)
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