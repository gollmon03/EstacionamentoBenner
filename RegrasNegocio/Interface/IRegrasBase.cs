using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio.Interface
{
    public interface IRegrasBase<T> where T : class
    {
        void Adicionar(T entidade);
        T buscarporID(int Id);
        IList<T> buscarTodos();

        void Atualizar(T entidade);

        void Remover(T entidade);

    }
}
