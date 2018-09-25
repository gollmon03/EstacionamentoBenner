using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Models;
using Repository.DAO;

namespace RegrasNegocio.Regras
{
    public class TabelaPrecoRegras : RegrasBase<TabelaPreco>
    {
        TabelaPrecoRepository tabelaprecorepository;

        public TabelaPrecoRegras()
        {
            tabelaprecorepository = new TabelaPrecoRepository();
        }

        public override IList<TabelaPreco> buscarTodos()
        {
            var tabelaPrecos = base.buscarTodos();
            foreach (var item in tabelaPrecos)
            {
                item.TipoVeiculo = new TipoVeiculoRegras().buscarporID(item.TipoVeiculoId);
            }
            return tabelaPrecos;
        }

        public override void Adicionar(TabelaPreco entidade)
        {
            if (tabelaPrecoJaCadastrada(entidade.TipoVeiculoId))
                throw new Exception("Já eciste um cadastro para este Tipo de Veiculo");
            base.Adicionar(entidade);
        }

        private bool tabelaPrecoJaCadastrada(int tipoVeiculoId)
        {
            return tabelaprecorepository.BuscaPorIdTipoVeiculo(tipoVeiculoId) != null;
        }
    }
}
