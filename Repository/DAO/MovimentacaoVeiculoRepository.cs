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

        public IList<MovimentacaoVeiculo> BuscaTodosAtivos()
        {
            return Contexto.MovimentacaoVeiculos.Where(m => m.DataHoraSaida == null).ToList();
        }

        public IList<MovimentacaoVeiculo> BuscaTodosSemMensalitaPorMes(DateTime data)
        {
            return Contexto.MovimentacaoVeiculos.Where(m => m.MensalistaId == null &&
                                                            m.DataHoraSaida.Value.Month == data.Month &&
                                                            m.DataHoraSaida.Value.Year == data.Year).ToList();
        }

        public IList<MovimentacaoVeiculo> BuscaTodosNaoGeradosPorMes(DateTime data)
        {
            return Contexto.MovimentacaoVeiculos.Where(m => m.Gerado == false &&
                                                             m.DataHoraSaida.Value.Month == data.Month &&
                                                             m.DataHoraSaida.Value.Year == data.Year).ToList();
        }
    }
}
