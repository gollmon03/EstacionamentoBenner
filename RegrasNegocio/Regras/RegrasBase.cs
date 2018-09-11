using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegrasNegocio.Interface;
using Repository.DAO;

namespace RegrasNegocio.Regras
{
    public class RegrasBase<T> : IRegrasBase<T> where T : class
    {
        public RegrasBase()
        {
            repository = new RepositoryBase<T>();
        }

        private readonly RepositoryBase<T> repository;

        public virtual void Adicionar(T entidade)
        {
          repository.Adicionar(entidade);
        }

        public virtual void Atualizar(T entidade)
        {
            repository.Atualizar(entidade);
        }

        public virtual T buscarporID(int Id)
        {
            return repository.buscarporID(Id);
        }

        public virtual IList<T> buscarTodos()
        {
            return repository.buscarTodos();
        }

        public virtual void Remover(T entidade)
        {
            repository.Remover(entidade);
        }
    }
}
