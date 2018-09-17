using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Models;

namespace Repository.DAO
{
    public class TabelaPrecoRepository : RepositoryBase<TabelaPreco>
    {
        public TabelaPreco BuscaPorIdTipoVeiculo(int tipoVeiculoId)
        {
            return Contexto.TabelaPrecos.Where(t => t.TipoVeiculoId == tipoVeiculoId).FirstOrDefault();
        }
    }
}
