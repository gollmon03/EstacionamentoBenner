using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Models;
using Repository.DAO;

namespace RegrasNegocio.Regras
{
    public class MovimentacaoVeiculoRegras : RegrasBase<MovimentacaoVeiculo>
    {
        MovimentacaoVeiculoRepository movimentacaoveiculorepository;

        public MovimentacaoVeiculoRegras()
        {
            movimentacaoveiculorepository = new MovimentacaoVeiculoRepository();
        }
    }
}
