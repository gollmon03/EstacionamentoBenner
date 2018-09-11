using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Contexto;

namespace Repository.DAO
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected EstacionamentoContexto Contexto = new EstacionamentoContexto();

        public void Adicionar(T entidade)
        {
            Contexto.Set<T>().Add(entidade);
            Contexto.SaveChanges();
        }

        public void Atualizar(T entidade)
        {
            Contexto.Entry(entidade).State = EntityState.Modified;
            Contexto.SaveChanges();            
        }

        public T buscarporID(int Id)
        {
           return Contexto.Set<T>().Find(Id);       
        }

        public IList<T> buscarTodos()
        {
           return Contexto.Set<T>().ToList();
        }

        public void Remover(T entidade)
        {
            Contexto.Set<T>().Remove(entidade);
            Contexto.SaveChanges();
        }
    }
}
