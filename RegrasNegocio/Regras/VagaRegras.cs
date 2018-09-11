using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estacionamento.Models;
using Repository.DAO;

namespace RegrasNegocio.Regras
{
    public class VagaRegras : RegrasBase<Vaga>
    {
        VagaRepository vagarepository;

        public VagaRegras()
        {
            vagarepository = new VagaRepository();
        }
    }
}
