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

        public Vaga BuscarVagaLivre()
        {
            return vagarepository.BuscarVagaLivre();
        }

        public override IList<Vaga> buscarTodos()
        {
            var vagas = base.buscarTodos();
            foreach (var item in vagas)
            {
                item.Setor = new SetorRegras().buscarporID(item.SetorId);
            }
            return vagas;
        }
    }
}
