using RSBrasil.Model.Interface.Data;
using RSBrasil.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RSBrasil.Data
{
    public class Repositorio<T> : IRepositorioBase<T> where T : ModelBase
    {
        public List<T> Listar()
        {
            using (var context = new SistemaContext<T>())
            {
                var all = context.Entity.OrderBy(x => x.Id).ToList();
                return all;
            }
        }

        public T PesquisarPorId(long id)
        {
            using (var context = new SistemaContext<T>())
            {
                var all = context.Entity.Where(x => x.Id == id).FirstOrDefault();
                return all;
            }
        }

        public T Inserir(T entity)
        {
            using (var context = new SistemaContext<T>())
            {
                context.Entity.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public void InserirVarios(List<T> entities)
        {
            using (var context = new SistemaContext<T>())
            {
                context.Entity.AddRange(entities);
                context.SaveChanges();
            }
        }

        public void Atualizar(T entity)
        {
            using (var context = new SistemaContext<T>())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }

        public void AtualizarVarios(List<T> entities)
        {
            using (var context = new SistemaContext<T>())
            {
                context.UpdateRange(entities);
                context.SaveChanges();
            }
        }

        public void Excluir(T entity)
        {
            using (var context = new SistemaContext<T>())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        public void ExcluirVarios(List<T> entities)
        {
            using (var context = new SistemaContext<T>())
            {
                context.RemoveRange(entities);
                context.SaveChanges();
            }
        }

        public T BuscaQualquerParametro(Expression<Func<T, bool>> predicate)
        {
            using (var context = new SistemaContext<T>())
            {
                var result = context.Entity.Where(predicate).FirstOrDefault();
                return result;
            }
        }
    }
}
