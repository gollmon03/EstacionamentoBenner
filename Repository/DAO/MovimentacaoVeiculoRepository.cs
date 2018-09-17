using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Models;

namespace Repository.DAO
{
    public class MovimentacaoVeiculoRepository : RepositoryBase<MovimentacaoVeiculo>
    {
        public bool ExisteVeiculoCadastrdo(string placa)
        {
            var movimentacao = Contexto.MovimentacaoVeiculos.Where(v => v.PlacaVeiculo == placa && v.DataHoraSaida == null).ToList().FirstOrDefault();            
            return movimentacao != null;
        }
    }
}
